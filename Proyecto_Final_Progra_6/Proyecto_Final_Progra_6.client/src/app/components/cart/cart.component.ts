import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../services/cart.service';
import { OrderService } from '../../services/order.service';
import { AuthService } from '../../services/auth.service';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { OrderDetail } from '../../models/order-detail.model';
import { Order } from '../../models/order.model';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  cartItems: OrderDetail[] = [];
  isLoading = false;

  // Descuento por producto (hardcodeado por ahora, pero preparado para ser variable por producto)
  descuentoPorProducto: Record<number, { porcentaje: number, cantidadMinima: number }> = {
    // Ejemplo: producto 1 y 2
    1: { porcentaje: 5, cantidadMinima: 5 },
    2: { porcentaje: 10, cantidadMinima: 3 }
  };

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private authService: AuthService,
    private alertService: AlertService
  ) {
    this.cartService.cartItems$.subscribe(items => this.cartItems = items);
  }

  remove(productId: number) {
    this.cartService.removeFromCart(productId);
  }

  updateQuantity(productId: number, event: Event) {
    const input = event.target as HTMLInputElement;
    const quantity = Number(input.value);
    this.cartService.updateQuantity(productId, quantity);
  }

  clear() {
    this.cartService.clearCart();
  }

  realizarPedido() {
    if (this.cartItems.length === 0) {
      this.alertService.showMessage('El carrito está vacío', '', MessageSeverity.warn);
      return;
    }
    const user = this.authService.currentUser;
    if (!user) {
      this.alertService.showMessage('Debe iniciar sesión para realizar un pedido', '', MessageSeverity.error);
      return;
    }
    this.isLoading = true;
    // Descuento solo por línea: 5% si compra 5 o más unidades de un producto
    const detalles = this.cartItems.map(item => ({
      ...item,
      discount: item.quantity >= 5 ? item.unitPrice * item.quantity * 0.05 : 0
    }));
    const order: Order = {
      discount: 0, // No se aplica descuento global
      comments: '',
      customerId: Number(user.id),
      orderDetails: detalles
    };
    this.orderService.createOrder(order).subscribe({
      next: () => {
        this.alertService.showMessage('Pedido realizado con éxito', '', MessageSeverity.success);
        this.cartService.clearCart();
        this.isLoading = false;
      },
      error: (err) => {
        this.alertService.showMessage('Error al realizar el pedido', err?.error?.message || '', MessageSeverity.error);
        this.isLoading = false;
      }
    });
  }

  get totalAPagar(): number {
    // Suma de los totales por línea (precio con descuento por producto)
    return this.cartItems.reduce((sum, item) => sum + this.getTotalLinea(item), 0);
  }

  get subtotal(): number {
    // Suma de los precios sin descuento
    return this.cartItems.reduce((sum, item) => sum + item.unitPrice * item.quantity, 0);
  }

  getTotalLinea(item: OrderDetail): number {
    const regla = this.descuentoPorProducto[item.productId];
    if (!regla) return item.unitPrice * item.quantity;
    const aplica = item.quantity >= regla.cantidadMinima;
    const descuento = aplica ? item.unitPrice * item.quantity * (regla.porcentaje / 100) : 0;
    return item.unitPrice * item.quantity - descuento;
  }

  getDescuentoLinea(item: OrderDetail): number {
    const regla = this.descuentoPorProducto[item.productId];
    if (!regla) return 0;
    const aplica = item.quantity >= regla.cantidadMinima;
    return aplica ? item.unitPrice * item.quantity * (regla.porcentaje / 100) : 0;
  }

  getMensajeDescuento(item: OrderDetail): string | null {
    const regla = this.descuentoPorProducto[item.productId];
    if (!regla) return null;
    return `Compra ${regla.cantidadMinima} o más y obtén un ${regla.porcentaje}% de descuento en este producto.`;
  }
}

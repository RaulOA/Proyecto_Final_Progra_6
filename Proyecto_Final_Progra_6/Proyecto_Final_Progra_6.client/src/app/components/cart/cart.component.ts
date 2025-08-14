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
    // Lógica de descuento automática: 5% si compra 5 o más unidades de un producto
    const detalles = this.cartItems.map(item => ({
      ...item,
      discount: item.quantity >= 5 ? item.unitPrice * item.quantity * 0.05 : 0
    }));
    // Descuento global: 10% si el total de productos supera 10 unidades
    const totalUnidades = detalles.reduce((sum, d) => sum + d.quantity, 0);
    const orderDiscount = totalUnidades >= 10 ? detalles.reduce((sum, d) => sum + d.unitPrice * d.quantity, 0) * 0.10 : 0;
    const order: Order = {
      discount: orderDiscount,
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
    // Calcula el total a pagar considerando descuentos por línea y global
    const subtotal = this.cartItems.reduce((sum, item) => {
      const lineDiscount = item.quantity >= 5 ? item.unitPrice * item.quantity * 0.05 : 0;
      return sum + (item.unitPrice * item.quantity - lineDiscount);
    }, 0);
    const totalUnidades = this.cartItems.reduce((sum, d) => sum + d.quantity, 0);
    const globalDiscount = totalUnidades >= 10 ? subtotal * 0.10 : 0;
    return subtotal - globalDiscount;
  }
}

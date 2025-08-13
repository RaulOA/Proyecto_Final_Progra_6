import { Component } from '@angular/core';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CartService } from '../../services/cart.service';
import { OrderService } from '../../services/order.service';
import { AuthService } from '../../services/auth.service';
import { AlertService } from '../../services/alert.service';
import { Order } from '../../models/order.model';

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {
  comments = '';
  discount = 0;
  isLoading = false;

  constructor(
    private cartService: CartService,
    private orderService: OrderService,
    private authService: AuthService,
    private alertService: AlertService
  ) {}

  get cartItems() {
    return this.cartService.getCartItems();
  }

  submitOrder() {
    if (this.cartItems.length === 0) {
      this.alertService.showMessage('El carrito está vacío', 'error', true);
      return;
    }
    const user = this.authService.currentUser;
    if (!user) {
      this.alertService.showMessage('Debe iniciar sesión', 'error', true);
      return;
    }
    const order: Order = {
      discount: this.discount,
      comments: this.comments,
      customerId: user.id,
      orderDetails: this.cartItems
    };
    this.isLoading = true;
    this.orderService.createOrder(order).subscribe({
      next: () => {
        this.alertService.showMessage('Compra realizada con éxito', 'success', true);
        this.cartService.clearCart();
        this.isLoading = false;
      },
      error: err => {
        this.alertService.showMessage(err?.error?.error || 'Error al procesar la compra', 'error', true);
        this.isLoading = false;
      }
    });
  }
}

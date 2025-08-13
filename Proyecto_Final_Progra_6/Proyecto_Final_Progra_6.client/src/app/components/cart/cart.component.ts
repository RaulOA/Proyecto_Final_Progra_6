import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartService } from '../../services/cart.service';
import { OrderDetail } from '../../models/order-detail.model';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  cartItems: OrderDetail[] = [];

  constructor(private cartService: CartService) {
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
}

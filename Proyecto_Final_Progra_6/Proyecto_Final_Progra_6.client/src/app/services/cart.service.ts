import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';
import { OrderDetail } from '../models/order-detail.model';

@Injectable({ providedIn: 'root' })
export class CartService {
  private cartItemsSubject = new BehaviorSubject<OrderDetail[]>([]);
  cartItems$ = this.cartItemsSubject.asObservable();

  getCartItems(): OrderDetail[] {
    return this.cartItemsSubject.value;
  }

  addToCart(product: Product, quantity: number = 1): void {
    const items = [...this.cartItemsSubject.value];
    const idx = items.findIndex(i => i.productId === product.id);
    if (idx > -1) {
      items[idx].quantity += quantity;
    } else {
      items.push({
        productId: product.id,
        unitPrice: product.sellingPrice,
        quantity,
        discount: 0
      });
    }
    this.cartItemsSubject.next(items);
  }

  removeFromCart(productId: number): void {
    const items = this.cartItemsSubject.value.filter(i => i.productId !== productId);
    this.cartItemsSubject.next(items);
  }

  updateQuantity(productId: number, quantity: number): void {
    const items = [...this.cartItemsSubject.value];
    const idx = items.findIndex(i => i.productId === productId);
    if (idx > -1) {
      items[idx].quantity = quantity;
      this.cartItemsSubject.next(items);
    }
  }

  clearCart(): void {
    this.cartItemsSubject.next([]);
  }
}

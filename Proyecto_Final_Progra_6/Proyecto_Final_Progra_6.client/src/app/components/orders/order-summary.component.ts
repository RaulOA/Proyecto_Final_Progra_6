import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

export interface OrderProduct {
  name: string;
  quantity: number;
  price: number;
}

export interface OrderSummary {
  orderId: string;
  products: OrderProduct[];
  total: number;
  date: string;
}

@Component({
  selector: 'app-order-summary',
  standalone: true,
  imports: [CommonModule, TranslateModule],
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.scss']
})
export class OrderSummaryComponent {
  @Input() order: OrderSummary | null = null;
}

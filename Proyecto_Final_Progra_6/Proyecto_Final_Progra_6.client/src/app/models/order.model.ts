import { OrderDetail } from './order-detail.model';

export interface Order {
  id?: number;
  discount: number;
  comments?: string;
  customerId: number;
  orderDetails: OrderDetail[];
}

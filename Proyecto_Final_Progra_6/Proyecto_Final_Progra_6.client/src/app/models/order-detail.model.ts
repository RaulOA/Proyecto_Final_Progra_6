export interface OrderDetail {
  id?: number;
  unitPrice: number;
  quantity: number;
  discount: number;
  productId: number;
  product?: import('./product.model').Product;
}

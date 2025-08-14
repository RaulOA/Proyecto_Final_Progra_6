export interface Product {
  id: number;
  name: string;
  description?: string;
  icon?: string;
  buyingPrice: number;
  sellingPrice: number;
  unitsInStock: number;
  isActive: boolean;
  isDiscontinued: boolean;
  productCategoryId: number;
  discountPercent: number; // Porcentaje de descuento configurable por producto
}

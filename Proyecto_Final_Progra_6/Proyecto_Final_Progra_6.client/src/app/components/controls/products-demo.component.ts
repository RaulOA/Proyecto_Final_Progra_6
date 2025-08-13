/*
Autor: Raul Ortega Acuña
Archivo: products-demo.component.ts
Solución: Proyecto_Final_Progra_6
Proyecto: Proyecto_Final_Progra_6.client
Ruta: Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client/src/app/components/controls/products-demo.component.ts

Descripción:
Widget visual para mostrar productos/libros en el dashboard. Permite visualizar libros, buscar y agregar al carrito (usando CartService). Compatible con el backend y modelos existentes.

Historial de cambios:
1. 2024-05-01 - Creación inicial del widget de productos para dashboard.
*/

import { Component, OnInit, inject } from '@angular/core';
import { NgClass } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { Product } from '../../models/product.model';
import { ProductEndpoint } from '../../services/product-endpoint.service';
import { CartService } from '../../services/cart.service';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { fadeInOut } from '../../services/animations';

@Component({
  selector: 'app-products-demo',
  templateUrl: './products-demo.component.html',
  styleUrl: './products-demo.component.scss',
  animations: [fadeInOut],
  standalone: true,
  imports: [NgClass, FormsModule, TranslateModule]
})
export class ProductsDemoComponent implements OnInit {
  private productEndpoint = inject(ProductEndpoint);
  private cartService = inject(CartService);
  private alertService = inject(AlertService);

  products: Product[] = [];
  filteredProducts: Product[] = [];
  loading = true;
  search = '';

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.loading = true;
    this.productEndpoint.getProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.filteredProducts = data;
        this.loading = false;
      },
      error: (err) => {
        this.alertService.showMessage('Error', 'No se pudieron cargar los productos', MessageSeverity.error);
        this.loading = false;
      }
    });
  }

  onSearchChanged(value: string) {
    this.search = value;
    const term = value?.toLowerCase() ?? '';
    this.filteredProducts = this.products.filter(p =>
      p.name.toLowerCase().includes(term) ||
      (p.description?.toLowerCase().includes(term))
    );
  }

  addToCart(product: Product) {
    if (product.unitsInStock < 1) {
      this.alertService.showMessage('Sin stock', 'Este producto no está disponible', MessageSeverity.warn);
      return;
    }
    this.cartService.addToCart(product, 1);
    this.alertService.showMessage('Carrito', 'Producto agregado al carrito', MessageSeverity.success);
  }
}

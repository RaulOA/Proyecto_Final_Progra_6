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
import { CommonModule } from '@angular/common';
import { SearchBoxComponent } from './search-box.component';
import { TableColumn, NgxDatatableModule } from '@siemens/ngx-datatable';

@Component({
  selector: 'app-products-demo',
  templateUrl: './products-demo.component.html',
  styleUrl: './products-demo.component.scss',
  animations: [fadeInOut],
  standalone: true,
  imports: [SearchBoxComponent, NgxDatatableModule, FormsModule, NgClass, TranslateModule, CommonModule]
})
export class ProductsDemoComponent implements OnInit {
  private productEndpoint = inject(ProductEndpoint);
  private cartService = inject(CartService);
  private alertService = inject(AlertService);

  products: Product[] = [];
  rows: Product[] = [];
  loading = true;
  search = '';
  columns: TableColumn[] = [];

  ngOnInit() {
    this.loadProducts();
    this.columns = [
      { prop: 'name', name: $localize`:@@productsDemo.table.Name:Nombre`, sortable: true },
      { prop: 'description', name: $localize`:@@productsDemo.table.Description:Descripción`, sortable: true },
      { prop: 'sellingPrice', name: $localize`:@@productsDemo.table.Price:Precio`, sortable: true },
      { prop: 'unitsInStock', name: $localize`:@@productsDemo.table.Stock:Stock`, sortable: true },
      { name: '', sortable: false }
    ];
  }

  loadProducts() {
    this.loading = true;
    this.productEndpoint.getProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.rows = data;
        this.loading = false;
      },
      error: () => {
        this.alertService.showMessage('Error', 'No se pudieron cargar los productos', MessageSeverity.error);
        this.loading = false;
      }
    });
  }

  onSearchChanged(value: string) {
    this.search = value;
    const term = value?.toLowerCase() ?? '';
    this.rows = this.products.filter(p =>
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

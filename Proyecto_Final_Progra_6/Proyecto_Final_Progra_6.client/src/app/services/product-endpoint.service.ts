// ---------------------------------------
// Autor: Raul Ortega Acuña
// Archivo: product-endpoint.service.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client/src/app/services/product-endpoint.service.ts
//
// Descripción:
// Servicio Angular para consumir los endpoints de productos (libros) del backend.
// Permite obtener la lista de productos compatible con el modelo y API REST .NET 9.
//
// Historial de cambios:
// 1. 2024-05-01 - Creación inicial para integración de widget de productos en dashboard.
// ---------------------------------------

import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EndpointBase } from './endpoint-base.service';
import { ConfigurationService } from './configuration.service';
import { Product } from '../models/product.model';

@Injectable({ providedIn: 'root' })
export class ProductEndpoint extends EndpointBase {
  private http = inject(HttpClient);
  private configurations = inject(ConfigurationService);

  get productsUrl() { return this.configurations.baseUrl + '/api/product'; }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsUrl, this.requestHeaders).pipe(
      catchError(error => this.handleError(error, () => this.getProducts()))
    );
  }
}

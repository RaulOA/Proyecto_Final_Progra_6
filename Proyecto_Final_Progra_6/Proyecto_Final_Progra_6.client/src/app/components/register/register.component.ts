// ---------------------------------------
// Autor: Raul Ortega Acuña
// Archivo: register.component.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: src/app/components/register/register.component.ts
// Descripción: Componente para el registro de clientes en la Librería Universidad.
// Historial de cambios:
// 1. 2024-06-XX - Creación inicial del componente de registro de cliente.
// ---------------------------------------

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerRegister } from '../../models/customer-register.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class RegisterComponent {
  customer: CustomerRegister = {
    name: '',
    email: '',
    password: '',
    phoneNumber: '',
    address: '',
    city: '',
    gender: ''
  };
  isLoading = false;
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router) {}

  register() {
    this.isLoading = true;
    this.errorMessage = '';
    this.http.post('/api/customer', this.customer).subscribe({
      next: () => {
        this.isLoading = false;
        alert('Registro exitoso. Ahora puedes iniciar sesión.');
        this.router.navigate(['/login']);
      },
      error: err => {
        this.isLoading = false;
        this.errorMessage = err?.error?.message || 'Error al registrar cliente.';
      }
    });
  }
}

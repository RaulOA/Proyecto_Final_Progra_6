// ---------------------------------------
// Autor: Raul Ortega Acuña
// Archivo: app.module.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: src/app/app.module.ts
// Descripción: Módulo principal de la aplicación Angular. Registra manualmente los componentes y el router.
// Historial de cambios:
// 1. 2024-06-XX - Registro manual de RegisterComponent y configuración de RouterModule.
// ---------------------------------------

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';

const appRoutes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}

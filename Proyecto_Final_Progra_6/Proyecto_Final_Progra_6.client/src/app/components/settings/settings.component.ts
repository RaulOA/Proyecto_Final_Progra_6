// Autor: Raul Ortega Acuña
// Archivo: settings.component.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.client\src\app\components\settings\settings.component.ts

// Descripción o propósito del archivo:
// Componente de configuración de la aplicación Angular. Permite la gestión de pestañas de perfil, preferencias, usuarios y roles.
// Incluye lógica para determinar permisos de visualización y manejo de suscripciones de fragmentos de ruta.

// Historial de cambios:
// 1. 05/10/2023 - Estructura inicial y configuración de pestañas y permisos.

// Alertas Críticas:
// - Ninguna alerta crítica identificada hasta el momento.

import { Component, inject, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';

import { fadeInOut } from '../../services/animations';
import { AccountService } from '../../services/account.service';
import { Permissions } from '../../models/permission.model';
import { UserInfoComponent } from '../controls/user-info.component';
import { UserPreferencesComponent } from '../controls/user-preferences.component';
import { UsersManagementComponent } from '../controls/users-management.component';
import { RolesManagementComponent } from '../controls/roles-management.component';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.scss',
  animations: [fadeInOut],
  imports: [
    RouterLink, TranslateModule, NgbNavModule,
    UserInfoComponent, UserPreferencesComponent, UsersManagementComponent, RolesManagementComponent
  ]
})
export class SettingsComponent implements OnInit, AfterViewInit, OnDestroy {
  private router = inject(Router);
  public route = inject(ActivatedRoute);
  private accountService = inject(AccountService);

  readonly profileTab = 'profile';
  readonly preferencesTab = 'preferences';
  readonly usersTab = 'users';
  readonly rolesTab = 'roles';
  activeTab = '';
  showDatatable = false; // Retrasa la visualización de la tabla hasta que se muestre la pestaña para calcular correctamente los anchos de columna
  fragmentSubscription: Subscription | undefined;

  // ======================================================== INICIO - MÉTODOS DEL CICLO DE VIDA =========================================================
  // Métodos del ciclo de vida del componente Angular.
  ngOnInit() {
    this.fragmentSubscription = this.route.fragment.subscribe(fragment => this.setActiveTab(fragment));
  }

  ngAfterViewInit() {
    setTimeout(() => this.showDatatable = true);
  }

  ngOnDestroy() {
    this.fragmentSubscription?.unsubscribe();
  }
  // ========================================================= FIN - MÉTODOS DEL CICLO DE VIDA ==========================================================

  // ======================================================== INICIO - MÉTODOS AUXILIARES =========================================================
  // Métodos auxiliares para la gestión de pestañas y permisos.
  setActiveTab(fragment: string | null) {
    fragment = fragment?.toLowerCase() ?? this.profileTab;

    const canViewTab = fragment === this.profileTab || fragment === this.preferencesTab ||
      (fragment === this.usersTab && this.canViewUsers) || (fragment === this.rolesTab && this.canViewRoles);

    if (canViewTab)
      this.activeTab = fragment;
    else
      this.router.navigate([], { fragment: this.profileTab });
  }

  get canViewUsers() {
    return this.accountService.userHasPermission(Permissions.viewUsers);
  }

  get canViewRoles() {
    return this.accountService.userHasPermission(Permissions.viewRoles);
  }
  // ========================================================= FIN - MÉTODOS AUXILIARES ==========================================================
}

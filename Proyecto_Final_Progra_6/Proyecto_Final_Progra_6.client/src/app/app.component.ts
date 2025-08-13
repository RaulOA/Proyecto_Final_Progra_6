/*
Autor: Raul Ortega Acuña
Archivo: app.component.ts
Solución: Proyecto_Final_Progra_6
Proyecto: Proyecto_Final_Progra_6.client
Ruta: Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client/src/app/app.component.ts

Descripción o propósito del archivo:
Componente principal de la aplicación Angular. Gestiona la inicialización, autenticación, notificaciones, traducción de idioma y la interacción global de la interfaz de usuario. Cumple con los estándares de documentación y estructura definidos para Libreria Universidad.

Historial de cambios:
1. 27/04/2024 - Documentación y estandarización de comentarios según lineamientos de Libreria Universidad.
2. 27/04/2024 - Se agregaron encabezados de sección y traducción de comentarios al español conforme a los estándares del proyecto.
3. 27/04/2024 - Actualización de encabezado y metadatos conforme a Prompt Copilot.txt. Se revisó la congruencia de los metadatos y se eliminaron referencias a términos prohibidos.
4. 27/04/2024 - Documentación exhaustiva de todo el archivo y división en grandes secciones según estándares de Libreria Universidad.

Alertas Críticas:
- 27/04/2024 - Se recomienda revisar la gestión de errores en la carga de notificaciones para evitar bucles de reintentos excesivos.
*/

// ======================================================== INICIO - IMPORTACIONES Y DECLARACIONES =========================================================
// Importación de módulos, servicios y componentes necesarios para el funcionamiento global de la aplicación Angular.
import { Component, OnInit, OnDestroy, inject, Renderer2 } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { Subscription } from 'rxjs';
import { TranslateModule } from '@ngx-translate/core';
import { ToastaService, ToastaConfig, ToastOptions, ToastData, ToastaModule } from 'ngx-toasta';
import { NgbCollapseModule, NgbModal, NgbPopover } from '@ng-bootstrap/ng-bootstrap';
import { AlertService, AlertDialog, DialogType, AlertCommand, MessageSeverity } from './services/alert.service';
import { NotificationService } from './services/notification.service';
import { AppTranslationService } from './services/app-translation.service';
import { AccountService } from './services/account.service';
import { LocalStoreManager } from './services/local-store-manager.service';
import { AppTitleService } from './services/app-title.service';
import { AuthService } from './services/auth.service';
import { ConfigurationService } from './services/configuration.service';
import { Alertify } from './models/Alertify';
import { Permissions } from './models/permission.model';
import { LoginComponent } from './components/login/login.component';
import { NotificationsViewerComponent } from './components/controls/notifications-viewer.component';
// ======================================================== FIN - IMPORTACIONES Y DECLARACIONES =========================================================

// ======================================================== INICIO - DECLARACIÓN DE LA CLASE PRINCIPAL ===================================================
// Definición del componente principal de la aplicación Angular.
declare let alertify: Alertify;

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [
        ToastaModule, RouterLink, RouterLinkActive, NgbCollapseModule, NgbPopover, NotificationsViewerComponent,
        RouterOutlet, TranslateModule
    ]
})
export class AppComponent implements OnInit, OnDestroy {
  // ======================================================== INICIO - PROPIEDADES Y DEPENDENCIAS =========================================================
  // Inyección de servicios y declaración de propiedades para el control global de la aplicación.
  private toastaService = inject(ToastaService); // Servicio para notificaciones tipo toast
  private toastaConfig = inject(ToastaConfig); // Configuración global de toasta
  private accountService = inject(AccountService); // Servicio de cuentas y permisos
  private alertService = inject(AlertService); // Servicio de alertas y diálogos
  private modalService = inject(NgbModal); // Servicio para modales
  private notificationService = inject(NotificationService); // Servicio de notificaciones
  private authService = inject(AuthService); // Servicio de autenticación
  private translationService = inject(AppTranslationService); // Servicio de traducción
  configurations = inject(ConfigurationService); // Configuración global
  router = inject(Router); // Servicio de enrutamiento
  renderer = inject(Renderer2); // Servicio para manipulación del DOM

  isMenuCollapsed = true; // Estado del menú lateral
  isAppLoaded = false; // Indica si la app terminó de cargar
  isUserLoggedIn = false; // Estado de autenticación del usuario
  newNotificationCount = 0; // Número de notificaciones nuevas
  appTitle = 'Proyecto_Final_Progra_6'; // Título de la aplicación

  stickyToasties: number[] = []; // IDs de notificaciones persistentes

  dataLoadingConsecutiveFailures = 0; // Contador de fallos consecutivos al cargar datos
  notificationsLoadingSubscription: Subscription | undefined; // Suscripción a notificaciones
  languageChangedSubscription: Subscription | undefined; // Suscripción a cambios de idioma

  loginControl: LoginComponent | undefined; // Referencia al componente de login modal

  // ======================================================== FIN - PROPIEDADES Y DEPENDENCIAS =========================================================

  // ======================================================== INICIO - MÉTODOS UTILITARIOS Y GETTERS ====================================================
  /**
   * Función de traducción global para la aplicación.
   * @param key Clave de traducción o arreglo de claves
   * @param interpolateParams Parámetros para interpolación
   */
  gT = (key: string | string[], interpolateParams?: object) =>
    this.translationService.getTranslation(key, interpolateParams);

  /**
   * Devuelve el título de la sección de notificaciones, incluyendo el conteo de nuevas si existen.
   */
  get notificationsTitle() {
    if (this.newNotificationCount) {
      return `${this.gT('app.Notifications')} (${this.newNotificationCount} ${this.gT('app.New')})`;
    } else {
      return this.gT('app.Notifications');
    }
  }
  // ======================================================== FIN - MÉTODOS UTILITARIOS Y GETTERS =======================================================

  // ======================================================== INICIO - CONSTRUCTOR ======================================================================
  /**
   * Constructor principal. Inicializa servicios, configuración de notificaciones y título de la app.
   */
  constructor() {
    const storageManager = inject(LocalStoreManager);
    storageManager.initialiseStorageSyncListener(); // Sincroniza almacenamiento local
    this.toastaConfig.theme = 'bootstrap';
    this.toastaConfig.position = 'top-right';
    this.toastaConfig.limit = 100;
    this.toastaConfig.showClose = true;
    this.toastaConfig.showDuration = false;
    AppTitleService.appName = this.appTitle;
  }
  // ======================================================== FIN - CONSTRUCTOR ========================================================================

  // ======================================================== INICIO - MÉTODOS DE CICLO DE VIDA =========================================================
  /**
   * Método de inicialización. Configura estado de autenticación, listeners de idioma y alertas.
   */
  ngOnInit() {
    this.isUserLoggedIn = this.authService.isLoggedIn;
    // Espera para mostrar información precargada
    setTimeout(() => this.isAppLoaded = true, 1000);
    setTimeout(() => {
      if (this.isUserLoggedIn) {
        this.alertService.resetStickyMessage();
        this.alertService.showMessage(this.gT('app.alerts.Login'), this.gT('app.alerts.WelcomeBack',
          { username: this.userName }), MessageSeverity.default);
      }
    }, 2000);
    // Suscripción a cambios de idioma
    this.languageChangedSubscription = this.translationService.languageChanged$
      .subscribe(event => {
        this.renderer.setAttribute(document.documentElement, 'dir', event.lang === 'ar' ? 'rtl' : 'ltr');
        this.renderer.setAttribute(document.documentElement, 'lang', event.lang);
      });
    // Suscripción a eventos de alerta y mensajes
    this.alertService.getDialogEvent().subscribe(alert => this.showDialog(alert));
    this.alertService.getMessageEvent().subscribe(message => this.showToast(message));
    // Delegado para re-login
    this.authService.reLoginDelegate = () => this.openLoginModal();
    // Suscripción a cambios de estado de login
    this.authService.getLoginStatusEvent().subscribe(isLoggedIn => {
      this.isUserLoggedIn = isLoggedIn;
      if (this.isUserLoggedIn) {
        this.initNotificationsLoading();
      } else {
        this.unsubscribeNotifications();
      }
      setTimeout(() => {
        if (!this.isUserLoggedIn) {
          this.alertService.showMessage(this.gT('app.alerts.SessionEnded'), '', MessageSeverity.default);
        }
      }, 500);
    });
  }

  /**
   * Método de destrucción. Cancela suscripciones activas.
   */
  ngOnDestroy() {
    this.unsubscribeNotifications();
    this.languageChangedSubscription?.unsubscribe();
  }
  // ======================================================== FIN - MÉTODOS DE CICLO DE VIDA ============================================================

  // ======================================================== INICIO - MÉTODOS DE NOTIFICACIONES ========================================================
  /**
   * Cancela la suscripción a la carga periódica de notificaciones.
   */
  private unsubscribeNotifications() {
    this.notificationsLoadingSubscription?.unsubscribe();
  }

  /**
   * Inicializa la carga periódica de notificaciones nuevas.
   * Si hay errores consecutivos, muestra mensaje de error persistente.
   */
  initNotificationsLoading() {
    this.notificationsLoadingSubscription = this.notificationService.getNewNotificationsPeriodically()
      .subscribe({
        next: notifications => {
          this.dataLoadingConsecutiveFailures = 0;
          this.newNotificationCount = notifications.filter(n => !n.isRead).length;
        },
        error: error => {
          this.alertService.logError(error);
          if (this.dataLoadingConsecutiveFailures++ < 20) {
            setTimeout(() => this.initNotificationsLoading(), 5000);
          } else {
            this.alertService.showStickyMessage(this.gT('app.alerts.LoadingError'),
              this.gT('app.alerts.LoadingNewNotificationsFailed'), MessageSeverity.error);
          }
        }
      });
  }

  /**
   * Marca todas las notificaciones nuevas como leídas y actualiza el contador.
   */
  markNotificationsAsRead() {
    const newNotifications = this.notificationService.newNotifications;
    if (newNotifications) {
      this.notificationService.readUnreadNotification(newNotifications.map(n => n.id), true)
        .subscribe({
          next: () => {
            for (const n of newNotifications) {
              n.isRead = true;
            }
            this.newNotificationCount = newNotifications.filter(n => !n.isRead).length;
          },
          error: error => {
            this.alertService.logError(error);
            this.alertService.showMessage(this.gT('app.alerts.NotificationError'),
              this.gT('app.alerts.MarkingReadNotificationsFailed'), MessageSeverity.error);
          }
        });
    }
  }
  // ======================================================== FIN - MÉTODOS DE NOTIFICACIONES ===========================================================

  // ======================================================== INICIO - MÉTODOS DE AUTENTICACIÓN Y DIÁLOGOS ===============================================
  /**
   * Abre el modal de inicio de sesión y gestiona los eventos de cierre y expiración de sesión.
   */
  openLoginModal() {
    const modalRef = this.modalService.open(LoginComponent, {
      windowClass: 'login-control',
      modalDialogClass: 'h-75 d-flex flex-column justify-content-center my-0',
      size: 'lg',
      backdrop: 'static'
    });
    this.loginControl = modalRef.componentInstance as LoginComponent;
    this.loginControl.isModal = true;
    this.loginControl.modalClosedCallback = () => modalRef.close();
    modalRef.shown.subscribe(() => {
      this.alertService.showStickyMessage(this.gT('app.alerts.SessionExpired'),
        this.gT('app.alerts.SessionExpiredLoginAgain'), MessageSeverity.info);
    });
    modalRef.hidden.subscribe(() => {
      this.alertService.resetStickyMessage();
      this.loginControl?.reset();
      if (this.authService.isSessionExpired) {
        this.alertService.showStickyMessage(this.gT('app.alerts.SessionExpired'),
          this.gT('app.alerts.SessionExpiredLoginToRenewSession'), MessageSeverity.warn);
      }
    });
  }

  /**
   * Muestra un diálogo de alerta, confirmación o prompt según el tipo recibido.
   * @param dialog Objeto de tipo AlertDialog con la información del diálogo.
   */
  showDialog(dialog: AlertDialog) {
    alertify.set({
      labels: {
        ok: dialog.okLabel || this.gT('app.alerts.OK'),
        cancel: dialog.cancelLabel || this.gT('app.alerts.Cancel')
      }
    });
    switch (dialog.type) {
      case DialogType.alert:
        alertify.alert(dialog.message);
        break;
      case DialogType.confirm:
        alertify.confirm(dialog.message, ok => {
          if (ok) {
            if (dialog.okCallback)
              dialog.okCallback();
          } else {
            if (dialog.cancelCallback) {
              dialog.cancelCallback();
            }
          }
        });
        break;
      case DialogType.prompt:
        alertify.prompt(dialog.message, (ok, val) => {
          if (ok) {
            if (dialog.okCallback)
              dialog.okCallback(val);
          } else {
            if (dialog.cancelCallback) {
              dialog.cancelCallback();
            }
          }
        }, dialog.defaultValue);
        break;
    }
  }

  /**
   * Muestra una notificación tipo toast según la severidad y operación indicada.
   * @param alert Comando de alerta recibido.
   */
  showToast(alert: AlertCommand) {
    if (alert.operation === 'clear') {
      for (const id of this.stickyToasties.slice(0)) {
        this.toastaService.clear(id);
      }
      return;
    }
    const toastOptions: ToastOptions = {
      title: alert.message?.summary,
      msg: alert.message?.detail,
    };
    if (alert.operation === 'add_sticky') {
      toastOptions.timeout = 0;
      toastOptions.onAdd = (toast: ToastData) => {
        this.stickyToasties.push(toast.id);
      };
      toastOptions.onRemove = (toast: ToastData) => {
        const index = this.stickyToasties.indexOf(toast.id, 0);
        if (index > -1) {
          this.stickyToasties.splice(index, 1);
        }
        if (alert.onRemove) {
          alert.onRemove();
        }
        toast.onAdd = undefined;
        toast.onRemove = undefined;
      };
    } else {
      toastOptions.timeout = 4000;
    }
    switch (alert.message?.severity) {
      case MessageSeverity.default: this.toastaService.default(toastOptions); break;
      case MessageSeverity.info: this.toastaService.info(toastOptions); break;
      case MessageSeverity.success: this.toastaService.success(toastOptions); break;
      case MessageSeverity.error: this.toastaService.error(toastOptions); break;
      case MessageSeverity.warn: this.toastaService.warning(toastOptions); break;
      case MessageSeverity.wait: this.toastaService.wait(toastOptions); break;
    }
  }

  /**
   * Cierra la sesión del usuario y redirige al login.
   */
  logout() {
    this.authService.logout();
    this.authService.redirectLogoutUser();
  }
  // ======================================================== FIN - MÉTODOS DE AUTENTICACIÓN Y DIÁLOGOS ==================================================

  // ======================================================== INICIO - MÉTODOS UTILITARIOS Y GETTERS AVANZADOS ===========================================
  /**
   * Devuelve el año actual en formato UTC.
   */
  getYear() {
    return new Date().getUTCFullYear();
  }

  /**
   * Devuelve el nombre de usuario actual autenticado.
   */
  get userName(): string {
    return this.authService.currentUser?.userName ?? '';
  }

  /**
   * Devuelve el nombre completo del usuario autenticado.
   */
  get fullName(): string {
    return this.authService.currentUser?.fullName ?? '';
  }

  /**
   * Indica si el usuario puede ver clientes (permiso de ejemplo).
   */
  get canViewCustomers() {
    return this.accountService.userHasPermission(Permissions.viewUsers); // Ejemplo: permiso para ver clientes
  }

  /**
   * Indica si el usuario puede ver productos (permiso de ejemplo).
   */
  get canViewProducts() {
    return this.accountService.userHasPermission(Permissions.viewUsers); // Ejemplo: permiso para ver productos
  }

  /**
   * Indica si el usuario puede ver órdenes (permiso de ejemplo).
   */
  get canViewOrders() {
    return !!true; // Ejemplo: permiso para ver órdenes
  }
  // ======================================================== FIN - MÉTODOS UTILITARIOS Y GETTERS AVANZADOS ==============================================
}
// ======================================================== FIN - DECLARACIÓN DE LA CLASE PRINCIPAL =====================================================

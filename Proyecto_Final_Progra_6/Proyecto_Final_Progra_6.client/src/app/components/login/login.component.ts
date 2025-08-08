// ================================================================================
// Autor: Raul Ortega Acuña
// Archivo: login.component.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6.client\src\app\components\login\login.component.ts
//
// Descripción o propósito del archivo:
// Componente Angular para la pantalla de autenticación (Login) que utiliza 
// formularios reactivos con validaciones. Integra con el servicio de 
// autenticación y maneja la redirección de usuarios autenticados.
//
// Historial de cambios:
// 1. 08/08/2025 - Conversión de formularios template-driven a reactive forms.
//               - Actualización de documentación según estándares del proyecto.
//
// Alertas Críticas:
// - Ninguna
// ================================================================================

import { Component, OnInit, OnDestroy, Input, inject } from '@angular/core';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, MessageSeverity, DialogType } from '../../services/alert.service';
import { AuthService } from '../../services/auth.service';
import { ConfigurationService } from '../../services/configuration.service';
import { Utilities } from '../../services/utilities';
import { UserLogin } from '../../models/user-login.model';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.scss',
    imports: [ReactiveFormsModule, NgClass, RouterLink, TranslateModule]
})

export class LoginComponent implements OnInit, OnDestroy {
  private alertService = inject(AlertService);
  private authService = inject(AuthService);
  private configurations = inject(ConfigurationService);
  private formBuilder = inject(FormBuilder);

  loginForm!: FormGroup;
  isLoading = false;
  loginStatusSubscription: Subscription | undefined;
  modalClosedCallback: (() => void) | undefined;

  @Input()
  isModal = false;

  ngOnInit() {
    this.buildForm();

    if (this.getShouldRedirect()) {
      this.authService.redirectLoginUser();
    } else {
      this.loginStatusSubscription = this.authService.getLoginStatusEvent().subscribe(() => {
        if (this.getShouldRedirect()) {
          this.authService.redirectLoginUser();
        }
      });
    }
  }

  ngOnDestroy() {
    this.loginStatusSubscription?.unsubscribe();
  }

  private buildForm() {
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      rememberMe: [this.authService.rememberMe]
    });
  }

  getShouldRedirect() {
    return !this.isModal && this.authService.isLoggedIn && !this.authService.isSessionExpired;
  }

  showErrorAlert(caption: string, message: string) {
    this.alertService.showMessage(caption, message, MessageSeverity.error);
  }

  closeModal() {
    if (this.modalClosedCallback) {
      this.modalClosedCallback();
    }
  }

  login() {
    if (this.loginForm.invalid) {
      this.markFormGroupTouched();
      return;
    }

    this.isLoading = true;
    this.alertService.startLoadingMessage('', 'login.alerts.AttemptingLogin');

    const formValue = this.loginForm.value;
    
    this.authService.loginWithPassword(formValue.userName, formValue.password, formValue.rememberMe)
      .subscribe({
        next: user => {
          setTimeout(() => {
            this.alertService.stopLoadingMessage();
            this.isLoading = false;
            this.resetForm();

            if (!this.isModal) {
              this.alertService.showMessage('login.alerts.Login', `login.alerts.Welcome`, MessageSeverity.success);
            } else {
              this.alertService.showMessage('login.alerts.Login', `login.alerts.UserSessionRestored`, MessageSeverity.success);
              setTimeout(() => {
                this.alertService.showStickyMessage('login.alerts.SessionRestored', 'login.alerts.RetryLastOperation', MessageSeverity.default);
              }, 500);

              this.closeModal();
            }
          }, 500);
        },
        error: error => {
          this.alertService.stopLoadingMessage();

          if (Utilities.checkNoNetwork(error)) {
            this.alertService.showStickyMessage(Utilities.noNetworkMessageCaption, Utilities.noNetworkMessageDetail, MessageSeverity.error, error);
            this.offerBackendDevServer();
          } else {
            const errorMessage = Utilities.getHttpResponseMessage(error);

            if (errorMessage) {
              this.alertService.showStickyMessage('login.alerts.UnableToLogin', this.mapLoginErrorMessage(errorMessage), MessageSeverity.error, error);
            } else {
              this.alertService.showStickyMessage('login.alerts.UnableToLogin',
                'login.alerts.LoginErrorOccurred', MessageSeverity.error, error);
            }
          }

          setTimeout(() => {
            this.isLoading = false;
          }, 500);
        }
      });
  }

  private markFormGroupTouched() {
    Object.keys(this.loginForm.controls).forEach(key => {
      const control = this.loginForm.get(key);
      control?.markAsTouched();
    });
  }

  offerBackendDevServer() {
    if (Utilities.checkIsLocalHost(location.origin) && Utilities.checkIsLocalHost(this.configurations.baseUrl)) {
      this.alertService.showDialog(
        'login.alerts.DeveloperDemoApiNotice', DialogType.prompt, value => {
          this.configurations.baseUrl = value as string;
          this.alertService.showStickyMessage('login.alerts.ApiChanged', 'login.alerts.ApiChangedTo', MessageSeverity.warn);
        },
        null,
        null,
        null,
        this.configurations.fallbackBaseUrl);
    }
  }

  mapLoginErrorMessage(error: string) {
    if (error === 'invalid_username_or_password') {
      return 'login.alerts.InvalidUsernameOrPassword';
    }

    return error;
  }

  reset() {
    this.resetForm();
  }

  resetForm() {
    this.loginForm.reset({
      userName: '',
      password: '',
      rememberMe: this.authService.rememberMe
    });
  }

  // ======================================================== INICIO - GETTERS PARA VALIDACIÓN =========================================================
  // Getters para acceder fácilmente a los controles del formulario y sus estados de validación
  // **********************************************************************************************************************************************
  get userName() { return this.loginForm.get('userName'); }
  get password() { return this.loginForm.get('password'); }
  get rememberMe() { return this.loginForm.get('rememberMe'); }
  // ======================================================== FIN - GETTERS PARA VALIDACIÓN ============================================================
}

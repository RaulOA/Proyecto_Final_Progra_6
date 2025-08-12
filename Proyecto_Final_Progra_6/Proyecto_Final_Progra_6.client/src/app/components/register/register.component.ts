// ================================================================================
// Autor: Raul Ortega Acuña
// Archivo: register.component.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6.client\src\app\components\register\register.component.ts
//
// Descripción o propósito del archivo:
// Componente Angular para el registro de nuevos usuarios que utiliza 
// formularios reactivos con validaciones avanzadas. Integra con el servicio 
// de cuentas para crear nuevos usuarios y maneja la autenticación automática.
//
// Historial de cambios:
// 1. 08/08/2025 - Creación inicial del componente de registro con formularios reactivos.
//
// Alertas Críticas:
// - Ninguna
// ================================================================================

import { Component, OnInit, inject } from '@angular/core';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { AlertService, MessageSeverity } from '../../services/alert.service';
import { AuthService } from '../../services/auth.service';
import { AccountService } from '../../services/account.service';
import { Utilities } from '../../services/utilities';
import { UserRegister } from '../../models/user-register.model';
import { UserEdit } from '../../models/user-edit.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  imports: [ReactiveFormsModule, NgClass, RouterLink, TranslateModule]
})
export class RegisterComponent implements OnInit {
  private alertService = inject(AlertService);
  private authService = inject(AuthService);
  private accountService = inject(AccountService);
  private formBuilder = inject(FormBuilder);

  registerForm!: FormGroup;
  isLoading = false;

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.registerForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(200)]],
      fullName: ['', [Validators.maxLength(200)]],
      jobTitle: ['', [Validators.maxLength(200)]],
      phoneNumber: ['', [Validators.maxLength(50)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    }, { validators: this.passwordMatchValidator });
  }

  // ======================================================== INICIO - VALIDADORES PERSONALIZADOS ======================================================
  // Validador personalizado para verificar que las contraseñas coincidan
  // **********************************************************************************************************************************************
  private passwordMatchValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (!password || !confirmPassword) {
      return null;
    }

    return password.value !== confirmPassword.value ? { 'passwordMismatch': true } : null;
  }
  // ======================================================== FIN - VALIDADORES PERSONALIZADOS =========================================================

  register() {
    if (this.registerForm.invalid) {
      this.markFormGroupTouched();
      return;
    }

    this.isLoading = true;
    this.alertService.startLoadingMessage('', 'register.alerts.RegisteringUser');

    const formValue = this.registerForm.value;
    
    // Crear el objeto UserEdit para el registro
    const newUser = new UserEdit();
    newUser.userName = formValue.userName;
    newUser.email = formValue.email;
    newUser.fullName = formValue.fullName;
    newUser.jobTitle = formValue.jobTitle;
    newUser.phoneNumber = formValue.phoneNumber;
    newUser.newPassword = formValue.password;
    newUser.confirmPassword = formValue.confirmPassword;

    this.accountService.newUser(newUser)
      .subscribe({
        next: user => {
          this.alertService.stopLoadingMessage();
          this.alertService.showMessage('register.alerts.Success', 'register.alerts.UserCreatedSuccessfully', MessageSeverity.success);

          // Intentar autenticación automática después del registro exitoso
          this.autoLogin(formValue.userName, formValue.password);
        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.isLoading = false;

          if (Utilities.checkNoNetwork(error)) {
            this.alertService.showStickyMessage(Utilities.noNetworkMessageCaption, Utilities.noNetworkMessageDetail, MessageSeverity.error, error);
          } else {
            const errorMessage = Utilities.getHttpResponseMessage(error);
            
            if (errorMessage) {
              this.alertService.showStickyMessage('register.alerts.SaveError', 'register.alerts.BelowRegistrationErrorsOccurred', MessageSeverity.error, error);
            } else {
              this.alertService.showStickyMessage('register.alerts.SaveError',
                'register.alerts.BelowRegistrationErrorsOccurred', MessageSeverity.error, error);
            }
          }
        }
      });
  }

  // ======================================================== INICIO - AUTO LOGIN ===================================================================
  // Método para autenticar automáticamente al usuario después del registro exitoso
  // **********************************************************************************************************************************************
  private autoLogin(userName: string, password: string) {
    this.alertService.startLoadingMessage('', 'register.alerts.AttemptingLogin');

    this.authService.loginWithPassword(userName, password, false)
      .subscribe({
        next: user => {
          setTimeout(() => {
            this.alertService.stopLoadingMessage();
            this.isLoading = false;
            this.alertService.showMessage('register.alerts.Login', 'register.alerts.WelcomeUser', MessageSeverity.success);
            this.alertService.showStickyMessage('register.alerts.Success', 'register.alerts.YourAccountCreatedSuccessfully', MessageSeverity.success);
          }, 500);
        },
        error: error => {
          this.alertService.stopLoadingMessage();
          this.isLoading = false;

          if (Utilities.checkNoNetwork(error)) {
            this.alertService.showStickyMessage(Utilities.noNetworkMessageCaption, Utilities.noNetworkMessageDetail, MessageSeverity.error, error);
          } else {
            const errorMessage = Utilities.getHttpResponseMessage(error);

            if (errorMessage) {
              this.alertService.showStickyMessage('register.alerts.UnableToLogin', this.mapLoginErrorMessage(errorMessage), MessageSeverity.error, error);
            } else {
              this.alertService.showStickyMessage('register.alerts.UnableToLogin',
                'register.alerts.LoginErrorOccurred', MessageSeverity.error, error);
            }
          }
        }
      });
  }
  // ======================================================== FIN - AUTO LOGIN =======================================================================

  private markFormGroupTouched() {
    Object.keys(this.registerForm.controls).forEach(key => {
      const control = this.registerForm.get(key);
      control?.markAsTouched();
    });
  }

  private mapLoginErrorMessage(error: string) {
    if (error === 'invalid_username_or_password') {
      return 'register.alerts.InvalidUsernameOrPassword';
    } else if (error === 'account_disabled') {
      return 'register.alerts.AccountDisabled';
    }

    return error;
  }

  resetForm() {
    this.registerForm.reset();
  }

  // ======================================================== INICIO - GETTERS PARA VALIDACIÓN =========================================================
  // Getters para acceder fácilmente a los controles del formulario y sus estados de validación
  // **********************************************************************************************************************************************
  get userName() { return this.registerForm.get('userName'); }
  get email() { return this.registerForm.get('email'); }
  get fullName() { return this.registerForm.get('fullName'); }
  get jobTitle() { return this.registerForm.get('jobTitle'); }
  get phoneNumber() { return this.registerForm.get('phoneNumber'); }
  get password() { return this.registerForm.get('password'); }
  get confirmPassword() { return this.registerForm.get('confirmPassword'); }
  
  get hasPasswordMismatch() {
    return this.registerForm.hasError('passwordMismatch') && 
           this.password?.touched && this.confirmPassword?.touched;
  }
  // ======================================================== FIN - GETTERS PARA VALIDACIÓN ============================================================
}
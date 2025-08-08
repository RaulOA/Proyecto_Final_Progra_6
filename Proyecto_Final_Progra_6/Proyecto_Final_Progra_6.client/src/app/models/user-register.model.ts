// ================================================================================
// Autor: Raul Ortega Acuña
// Archivo: user-register.model.ts
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6.client\src\app\models\user-register.model.ts
//
// Descripción o propósito del archivo:
// Modelo para el registro de nuevos usuarios que contiene todos los campos
// necesarios para la creación de una cuenta, incluyendo validaciones de 
// contraseña y confirmación.
//
// Historial de cambios:
// 1. 08/08/2025 - Creación inicial del modelo de registro de usuario.
//
// Alertas Críticas:
// - Ninguna
// ================================================================================

export class UserRegister {
  constructor(
    public userName = '',
    public email = '',
    public fullName = '',
    public password = '',
    public confirmPassword = '',
    public jobTitle = '',
    public phoneNumber = ''
  ) { }
}
// ===============================================================================================
// Autor: Raul Ortega Acuña
// Archivo: environment.ts
// Proyecto: Proyecto_Final_Progra_6.client
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.client\src\environments\environment.ts
//
// Descripción o propósito del archivo:
// Configuración de variables de entorno para la aplicación Angular en modo desarrollo.
// Permite definir la URL base de la API y un servidor alternativo de respaldo.
// Este archivo puede ser reemplazado durante el proceso de compilación por environment.prod.ts.
//
// Historial de cambios:
// 1. 25/07/2025 - Se agregaron comentarios de documentación y se actualizaron metadatos según estándares.
// 2. 24/07/2025 - Estructura inicial y configuración de URLs de desarrollo.
//
// Alertas Críticas:
// - 25/07/2025 - Se detectó referencia a quickapp.azurewebsites.net como servidor de respaldo. Se recomienda actualizar a una instancia propia.
// ===============================================================================================

import { Environment } from "../app/models/environment.model";

// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
/**
 * Configuración de entorno para desarrollo.
 *
 * @property production Indica si la aplicación está en modo producción.
 * @property baseUrl URL base del servidor API para desarrollo local.
 * @property fallbackBaseUrl URL alternativa para el servidor API en caso de que el local no esté disponible.
 */

export const environment: Environment = {
  production: false, // Indica que la aplicación está en modo desarrollo.
  baseUrl: "https://localhost:7085", // URL del servidor API local.
  fallbackBaseUrl: "https://quickapp.azurewebsites.net", // URL de respaldo para desarrollo sin API local.
};

/*
 * Para facilitar la depuración en modo desarrollo, puedes importar el siguiente archivo
 * para ignorar los frames de error relacionados con zone, como `zone.run` y `zoneDelegate.invokeTask`.
 *
 * Este import debe estar comentado en producción porque puede afectar el rendimiento si ocurre un error.
 */
// import 'zone.js/plugins/zone-error';  // Incluido con Angular CLI.

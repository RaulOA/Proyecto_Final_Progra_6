# Reglas de Codificaci�n, Documentaci�n y Comentariado � Librer�a Universitaria (.NET 9 + Angular)

---

## 1. Encabezado obligatorio para cada archivo

- Todos los archivos deben incluir un encabezado al inicio con los siguientes campos:
  - Autor
  - Archivo (nombre real)
  - Soluci�n
  - Proyecto
  - Ruta (ubicaci�n relativa)
  - Descripci�n o prop�sito del archivo (actualizado si cambia la funcionalidad)
  - Historial de cambios (fecha y descripci�n de cada modificaci�n significativa)
  - Alertas cr�ticas (documentar observaciones relevantes, riesgos, recomendaciones)

  - Ejemplo:

 ================== MODELO DE ENCABEZADO ==================
Autor: Raul Ortega Acu�a
Archivo: Program.cs
Soluci�n: Claudes 2.0
Proyecto: Claudes_2._0.Server
Ruta: Claudes 2.0\Claudes_2._0.Server\Program.cs

Descripci�n o prop�sito del archivo:
Configuraci�n y arranque de la aplicaci�n ASP.NET Core. Incluye la configuraci�n de 
servicios, autenticaci�n, autorizaci�n, OpenIddict, Swagger, CORS, AutoMapper y 
pipeline de peticiones HTTP. Realiza el registro de clientes OIDC y el seeding de la 
base de datos al iniciar.

Historial de cambios:
1. 23/07/2025 - Estructura inicial y configuraci�n de servicios principales.
2. 02/07/2025 - Actualizaci�n de referencias a OIDC: uso de LibreriaUniversidadSpaClientID en lugar de QuickAppClientID.
               - Mejoras en comentarios y consistencia.

Alertas Cr�ticas:
- 24/07/2025 - GitHub Copilot sugiri� el uso de una instancia p�blica para el endpoint OIDC. Se recomienda revisar 
              y configurar acceso seguro mediante restricciones de origen.
- 24/07/2025 - Observaci�n: el manejo de excepciones en AuthController carece de logging detallado. Puede 
              dificultar auditor�as ante fallos de autenticaci�n.
===========================================================
---

## 2. Reglas de formato y comentariado

- Los comentarios descriptivos deben estar en espa�ol, ubicados junto a la l�nea o secci�n relevante.
- No eliminar secciones comentadas como "Notas Importantes" o comentarios de c�digo que contengan informaci�n relevante para mantenimiento, configuraci�n, uso, desarrollo o descripci�n.
- Dividir el c�digo en grandes secciones, cada una con encabezado y pie explicativo usando el formato:
  ```
  ======================================================== INICIO - NOMBRE DE LA SECCI�N ========================================================
  // Descripci�n breve del prop�sito de esta secci�n.
  **********************************************************************************************************************************************
  // C�digo relacionado con la secci�n.
  ======================================================== FIN - NOMBRE DE LA SECCI�N ===========================================================
  ```
- Reemplazar todas las referencias a nombres de la plantilla original (ebenmonney, emonney, quickapp, Quick Application, template, etc.) por "Librer�a Universidad" o "Raul O.A" seg�n corresponda, siempre que no se rompan dependencias.
- Traducir texto en ingl�s al espa�ol, excepto nombres de variables o propiedades t�cnicas que deban mantenerse.
- Los metadatos deben ser congruentes con el contenido del archivo y actualizados seg�n corresponda.
- Actualizar URLs en comentarios y documentaci�n a las del repositorio del proyecto o documentaci�n oficial de .NET 9, Angular 19, OpenIddict, etc.

---

## 3. Reglas de codificaci�n y buenas pr�cticas

- Seguir las convenciones de nomenclatura de C#, TypeScript y tecnolog�as del stack para c�digo y documentaci�n XML.
- Mantener la coherencia visual y funcional del sistema.
- Priorizar la reutilizaci�n de componentes, servicios y estilos existentes.
- Mantener la modularidad y separaci�n de responsabilidades entre backend y frontend, y entre l�gica de negocio, datos y presentaci�n.
- No romper el est�ndar de estructura de carpetas y archivos definido por la plantilla base.
- Documentar cambios relevantes para facilitar el mantenimiento y la colaboraci�n.
- Considerar la seguridad y protecci�n de datos en cada etapa del desarrollo.

---

## 4. Reglas para commits y control de versiones

- Realizar commits y push frecuentes, especialmente tras cambios estructurales, integraci�n de dependencias, migraciones o implementaci�n de funcionalidades clave.
- Los mensajes de confirmaci�n deben seguir esta estructura:
  - L�nea 1: resumen breve del cambio realizado (m�x. 72 caracteres)
  - L�nea 2: en blanco
  - L�nea 3 en adelante: Archivo.extension: descripci�n completa del cambio con los detalles necesarios
- Si el commit cierra una incidencia, usar la sintaxis: `#123 closes`
- Ejemplo:
  ```
  Actualizado nombre de cliente OIDC a LibreriaUniversidadSpaClientID
  
  Program.cs: Se modific� para usar LibreriaUniversidadSpaClientID en lugar de QuickAppClientID. Se mejoraron comentarios y consistencia en los nombres del proyecto.
  ```

---

## 5. Reglas para migraciones de base de datos

- Cada migraci�n debe tener un nombre descriptivo que refleje el cambio realizado.
- Las migraciones deben ser generadas autom�ticamente usando `dotnet ef migrations add NombreMigracion` desde el proyecto Libreria_Universidad.Server.
- No modificar manualmente las migraciones generadas.
- Aplicar las migraciones al entorno de desarrollo local antes de hacer push al repositorio.
- Ejecutar `dotnet ef database update` para aplicar los cambios en la base de datos.

---

## 6. Reglas para documentaci�n t�cnica y manual de usuario

- Mantener la documentaci�n actualizada y clara, incluyendo arquitectura, diagramas, explicaci�n de componentes e instrucciones de instalaci�n y ejecuci�n.
- Documentar la estructura de carpetas y archivos, roles, permisos y flujos principales.
- Incluir referencias a documentaci�n oficial y al repositorio del proyecto.

---

## 7. Reglas para pruebas y calidad

- Escribir y ejecutar pruebas unitarias y de integraci�n (Jasmine/Karma para Angular, pruebas de endpoints en backend).
- Ejecutar an�lisis est�tico de c�digo (ESLint/angular-eslint para frontend).
- Probar la funcionalidad tras cada cambio estructural.

---

## 8. Reglas para internacionalizaci�n y accesibilidad

- Usar @ngx-translate/core para soportar m�ltiples idiomas en el frontend.
- Asegurar que la interfaz sea responsiva y accesible en diferentes dispositivos.

---

## 9. Reglas para seguridad y roles

- Implementar autenticaci�n y autorizaci�n basada en JWT, OIDC/OAuth2 y ASP.NET Core Identity.
- Restringir vistas y acciones seg�n el tipo de usuario (Administrador, Vendedor, Cliente).
- Proteger endpoints y reportes seg�n permisos.

---

## 10. Reglas para integraci�n y consumo de APIs

- Usar servicios Angular para consumir endpoints CRUD y reportes.
- Implementar interceptores para manejo de JWT y protecci�n de rutas.
- Documentar y probar la integraci�n entre backend y frontend.

---

## 11. Reglas para dise�o y experiencia de usuario

- Personalizar la interfaz, men�s y dashboard para la tem�tica de librer�a.
- Asegurar responsividad y usabilidad en todos los dispositivos.
- Mantener la coherencia visual y funcional en toda la aplicaci�n.

---

Este documento resume y estructura todas las reglas de codificaci�n, documentaci�n, comentariado y buenas pr�cticas expl�citas e impl�citas en los archivos analizados, para asegurar calidad, coherencia y mantenibilidad en el desarrollo del sistema.

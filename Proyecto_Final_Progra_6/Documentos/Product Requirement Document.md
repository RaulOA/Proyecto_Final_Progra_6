# PRD � Sistema de Inventario y Ventas para Librer�a Universitaria

---

## 1. Objetivo
Desarrollar una aplicaci�n web integral para la gesti�n de inventario y ventas de una librer�a universitaria, cubriendo autenticaci�n, administraci�n de entidades clave, reportes avanzados, dashboard informativo y diferenciaci�n de roles, utilizando Angular 19 (frontend), ASP.NET Core 9 (backend), Entity Framework Core (ORM), SQL Server (base de datos) y Crystal Reports (reportes).

---

## 2. Alcance Funcional

### 2.1. Autenticaci�n y Seguridad
- Registro, inicio y cierre de sesi�n de usuarios mediante JWT.
- Recuperaci�n y cambio de contrase�a.
- Diferenciaci�n de vistas y acciones seg�n roles (Administrador, Cliente).

### 2.2. Gesti�n de Entidades Principales
- CRUD completo para:
  - Libro (Producto)
  - Categor�a
  - Venta
  - Cliente
  - Proveedor (opcional)
- Validaciones de datos con FluentValidation.
- Relaciones uno a muchos y muchos a muchos entre entidades.

### 2.3. Dashboard Informativo
- Visualizaci�n de KPIs relevantes (ventas del d�a, stock bajo, productos m�s vendidos).
- Gr�ficos interactivos con Chart.js o ngx-charts.

### 2.4. Reportes
- Integraci�n de Crystal Reports para al menos dos reportes clave:
  - Ventas por periodo
  - Inventario bajo
- Exportaci�n de reportes a PDF y aplicaci�n de filtros.

### 2.5. Interfaz Web
- Dise�o responsivo e intuitivo con Bootstrap y SASS.
- Formularios reactivos y rutas protegidas en Angular.
- Internacionalizaci�n con @ngx-translate/core.

### 2.6. Consumo de APIs
- Servicios Angular para operaciones CRUD y reportes.
- Interceptores para manejo de JWT y seguridad.

---

## 3. Requisitos T�cnicos

### 3.1. Frontend
- Angular 19, TypeScript, Bootstrap 5, SASS.
- RxJS para programaci�n reactiva.
- ng2-charts/chart.js para visualizaci�n de datos.
- @ngx-translate/core para multilenguaje.
- Jasmine/Karma para pruebas unitarias.

### 3.2. Backend
- ASP.NET Core 9 Web API.
- Entity Framework Core 9 (Code First).
- SQL Server como base de datos.
- OIDC/OAuth2 y ASP.NET Core Identity para autenticaci�n/autorizaci�n.
- AutoMapper para mapeo de entidades/DTOs.
- Serilog para logging.
- Quartz para tareas programadas.
- Swashbuckle/Swagger para documentaci�n de APIs.
- Crystal Reports para reportes.

### 3.3. Infraestructura y DevOps
- Control de versiones con GitHub.
- Estructura modular y desacoplada (backend y frontend).
- Documentaci�n t�cnica y manual de usuario.
- Video demo y presentaci�n.

---

## 4. Estructura de la Soluci�n

### Backend (ASP.NET Core 9)
- Controllers: API REST para cada entidad y proceso.
- Models: Entidades de dominio (Libro, Categor�a, Venta, Cliente, Proveedor).
- Services: L�gica de negocio y servicios de aplicaci�n.
- Configuration: Seguridad, OIDC, mapeos.
- Migrations: Migraciones EF Core.
- Authorization: Handlers y filtros de autorizaci�n.
- Validation: Validadores FluentValidation.
- Email: Servicio de env�o de correos.
- Jobs: Tareas programadas (Quartz).

### Frontend (Angular 19)
- Components: Pantallas y formularios para cada entidad y proceso.
- Services: Consumo de APIs, autenticaci�n, almacenamiento local.
- Models: Modelos TypeScript.
- Routes: Definici�n de rutas y navegaci�n.
- Assets: Estilos, temas, scripts, internacionalizaci�n.
- Environments: Configuraci�n de entornos.

---

## 5. Roles y Permisos

- **Administrador:** Acceso total a todas las funcionalidades, reportes y configuraci�n.
- **Cliente:** Consulta de productos, historial de compras, acceso restringido.

---

## 6. Reportes y Dashboard

- Reporte de ventas por periodo (Crystal Reports, PDF, filtros por fecha/cliente).
- Reporte de inventario bajo (Crystal Reports, PDF, filtros por categor�a/stock).
- Dashboard con KPIs y gr�ficos de ventas, productos m�s vendidos, stock bajo.

---

## 7. Entregables

1. C�digo fuente completo en repositorio p�blico (GitHub).
2. Manual t�cnico (PDF) con arquitectura, diagramas, explicaci�n de componentes e instrucciones de instalaci�n.
3. Video demo (m�x. 10 minutos) o presentaci�n en clase.

---

## 8. Lineamientos de Desarrollo

- Respetar la estructura de carpetas y archivos definida en la plantilla.
- Seguir convenciones de nombres y modularidad.
- Documentar cambios relevantes y mantener coherencia visual y funcional.
- Realizar commits y push frecuentes con mensajes claros.
- Probar funcionalidad tras cada cambio estructural.

---

## 9. Criterios de Aceptaci�n

- Cumplimiento de todos los requisitos funcionales y t�cnicos.
- Interfaz responsiva y usabilidad probada en diferentes dispositivos.
- Seguridad y protecci�n de datos en cada etapa.
- Reportes funcionales y exportables.
- Documentaci�n y video demo completos y claros.

---

**Referencias:**  
- [Repositorio del proyecto](https://github.com/RaulOA/Libreria-Universidad)  
- Documentaci�n oficial de .NET 9, Angular 19, OpenIddict, Crystal Reports.

---

Este PRD resume y estructura todos los requerimientos, tecnolog�as, procesos y lineamientos para el desarrollo y entrega del sistema, asegurando claridad y congruencia con los archivos y est�ndares analizados.

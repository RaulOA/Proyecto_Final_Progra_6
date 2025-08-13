# PRD – Sistema de Inventario y Ventas para Librería Universitaria

---

## 1. Objetivo
Desarrollar una aplicación web integral para la gestión de inventario y ventas de una librería universitaria, cubriendo autenticación, administración de entidades clave, reportes avanzados, dashboard informativo y diferenciación de roles, utilizando Angular 19 (frontend), ASP.NET Core 9 (backend), Entity Framework Core (ORM), SQL Server (base de datos) y Crystal Reports (reportes).

---

## 2. Alcance Funcional

### 2.1. Autenticación y Seguridad
- Registro, inicio y cierre de sesión de usuarios mediante JWT.
- Recuperación y cambio de contraseña.
- Diferenciación de vistas y acciones según roles (Administrador, Cliente).

### 2.2. Gestión de Entidades Principales
- CRUD completo para:
  - Libro (Producto)
  - Categoría
  - Venta
  - Cliente
  - Proveedor (opcional)
- Validaciones de datos con FluentValidation.
- Relaciones uno a muchos y muchos a muchos entre entidades.

### 2.3. Dashboard Informativo
- Visualización de KPIs relevantes (ventas del día, stock bajo, productos más vendidos).
- Gráficos interactivos con Chart.js o ngx-charts.

### 2.4. Reportes
- Integración de Crystal Reports para al menos dos reportes clave:
  - Ventas por periodo
  - Inventario bajo
- Exportación de reportes a PDF y aplicación de filtros.

### 2.5. Interfaz Web
- Diseño responsivo e intuitivo con Bootstrap y SASS.
- Formularios reactivos y rutas protegidas en Angular.
- Internacionalización con @ngx-translate/core.

### 2.6. Consumo de APIs
- Servicios Angular para operaciones CRUD y reportes.
- Interceptores para manejo de JWT y seguridad.

---

## 3. Requisitos Técnicos

### 3.1. Frontend
- Angular 19, TypeScript, Bootstrap 5, SASS.
- RxJS para programación reactiva.
- ng2-charts/chart.js para visualización de datos.
- @ngx-translate/core para multilenguaje.
- Jasmine/Karma para pruebas unitarias.

### 3.2. Backend
- ASP.NET Core 9 Web API.
- Entity Framework Core 9 (Code First).
- SQL Server como base de datos.
- OIDC/OAuth2 y ASP.NET Core Identity para autenticación/autorización.
- AutoMapper para mapeo de entidades/DTOs.
- Serilog para logging.
- Quartz para tareas programadas.
- Swashbuckle/Swagger para documentación de APIs.
- Crystal Reports para reportes.

### 3.3. Infraestructura y DevOps
- Control de versiones con GitHub.
- Estructura modular y desacoplada (backend y frontend).
- Documentación técnica y manual de usuario.
- Video demo y presentación.

---

## 4. Estructura de la Solución

### Backend (ASP.NET Core 9)
- Controllers: API REST para cada entidad y proceso.
- Models: Entidades de dominio (Libro, Categoría, Venta, Cliente, Proveedor).
- Services: Lógica de negocio y servicios de aplicación.
- Configuration: Seguridad, OIDC, mapeos.
- Migrations: Migraciones EF Core.
- Authorization: Handlers y filtros de autorización.
- Validation: Validadores FluentValidation.
- Email: Servicio de envío de correos.
- Jobs: Tareas programadas (Quartz).

### Frontend (Angular 19)
- Components: Pantallas y formularios para cada entidad y proceso.
- Services: Consumo de APIs, autenticación, almacenamiento local.
- Models: Modelos TypeScript.
- Routes: Definición de rutas y navegación.
- Assets: Estilos, temas, scripts, internacionalización.
- Environments: Configuración de entornos.

---

## 5. Roles y Permisos

- **Administrador:** Acceso total a todas las funcionalidades, reportes y configuración.
- **Cliente:** Consulta de productos, historial de compras, acceso restringido.

---

## 6. Reportes y Dashboard

- Reporte de ventas por periodo (Crystal Reports, PDF, filtros por fecha/cliente).
- Reporte de inventario bajo (Crystal Reports, PDF, filtros por categoría/stock).
- Dashboard con KPIs y gráficos de ventas, productos más vendidos, stock bajo.

---

## 7. Entregables

1. Código fuente completo en repositorio público (GitHub).
2. Manual técnico (PDF) con arquitectura, diagramas, explicación de componentes e instrucciones de instalación.
3. Video demo (máx. 10 minutos) o presentación en clase.

---

## 8. Lineamientos de Desarrollo

- Respetar la estructura de carpetas y archivos definida en la plantilla.
- Seguir convenciones de nombres y modularidad.
- Documentar cambios relevantes y mantener coherencia visual y funcional.
- Realizar commits y push frecuentes con mensajes claros.
- Probar funcionalidad tras cada cambio estructural.

---

## 9. Criterios de Aceptación

- Cumplimiento de todos los requisitos funcionales y técnicos.
- Interfaz responsiva y usabilidad probada en diferentes dispositivos.
- Seguridad y protección de datos en cada etapa.
- Reportes funcionales y exportables.
- Documentación y video demo completos y claros.

---

**Referencias:**  
- [Repositorio del proyecto](https://github.com/RaulOA/Libreria-Universidad)  
- Documentación oficial de .NET 9, Angular 19, OpenIddict, Crystal Reports.

---

Este PRD resume y estructura todos los requerimientos, tecnologías, procesos y lineamientos para el desarrollo y entrega del sistema, asegurando claridad y congruencia con los archivos y estándares analizados.

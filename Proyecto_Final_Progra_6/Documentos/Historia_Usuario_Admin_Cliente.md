# Historias de Usuario Ultra Detalladas: Admin y Cliente

---

## Introducción y Contexto

Este documento describe historias de usuario ultra detalladas para los roles Admin y Cliente, alineadas con los requerimientos funcionales del PRD y la estructura actual del sistema. Además, integra las reglas de codificación, documentación y buenas prácticas del proyecto para asegurar calidad, coherencia y mantenibilidad.

Cada paso indica:
- Qué hace el usuario
- Qué ve en la interfaz (según los componentes y servicios existentes)
- Qué acciones ejecuta y qué ocurre después
- Dónde se encuentran las funcionalidades en la solución actual
- Si la funcionalidad está presente, y si requiere ajustes para encajar en la estructura
- Qué reglas y buenas prácticas aplican en cada flujo

---

## Reglas de Codificación, Documentación y Buenas Prácticas

- Todos los archivos deben incluir encabezado con autor, nombre, solución, proyecto, ruta, propósito, historial de cambios y alertas críticas.
- Los comentarios descriptivos deben estar en español y ubicados junto a la sección relevante.
- Mantener la coherencia visual y funcional, modularidad y separación de responsabilidades.
- Priorizar la reutilización de componentes, servicios y estilos existentes.
- No romper la estructura de carpetas y archivos definida por la plantilla base.
- Documentar cambios relevantes y mantener la documentación técnica actualizada.
- Escribir y ejecutar pruebas unitarias e integración (Jasmine/Karma para Angular, pruebas de endpoints en backend).
- Ejecutar análisis estático de código (ESLint/angular-eslint para frontend).
- Usar @ngx-translate/core para multilenguaje y asegurar accesibilidad y responsividad.
- Implementar autenticación y autorización basada en JWT, OIDC/OAuth2 y ASP.NET Core Identity.
- Restringir vistas y acciones según el tipo de usuario (Admin, Cliente).
- Usar servicios Angular para consumir endpoints CRUD y reportes, con interceptores para JWT y protección de rutas.
- Personalizar la interfaz, menús y dashboard para la temática de librería.
- Mantener la coherencia visual y funcional en toda la aplicación.

---

## Rol: Admin

### Flujo: Gestión Completa del Sistema

1. **Inicio de Sesión**
   - El Admin accede a la pantalla de login (`src/app/components/login/login.component.ts`).
   - Ingresa usuario/correo y contraseña.
   - El sistema valida credenciales usando servicios de autenticación (`src/app/services/auth.service.ts`, backend: `AuthorizationController.cs`).
   - Si son válidas, accede al panel principal; si no, ve mensajes de error.
   - **Presente:** Sí. No requiere ajuste.
   - **Reglas aplicadas:** Encabezado, comentarios, autenticación JWT/OIDC, pruebas unitarias, documentación técnica.

2. **Navegación por el Menú**
   - Ve un menú lateral o superior (`src/app/components/controls/menu.component.ts` o similar) con acceso a Catálogo, Dashboard, Gestión de Clientes, Gestión de Libros, Perfil.
   - Las opciones visibles corresponden a su rol, gestionadas por guards (`src/app/services/auth-guard.ts`).
   - **Presente:** Sí. Revisar que los guards y permisos estén correctamente configurados para Admin.
   - **Reglas aplicadas:** Modularidad, reutilización, restricción por rol, comentarios, pruebas de navegación.

3. **Visualización del Dashboard**
   - Accede al dashboard informativo (`src/app/components/controls/statistics-demo.component.ts`).
   - Ve KPIs y gráficas (ng2-charts, chart.js).
   - El panel es responsivo (Bootstrap 5).
   - **Presente:** Sí. Revisar que los datos mostrados sean los requeridos por el PRD.
   - **Reglas aplicadas:** Personalización, coherencia visual, pruebas de componentes, documentación de KPIs.

4. **Gestión de Libros**
   - Accede al catálogo de libros (`src/app/components/products/products.component.ts`).
   - Visualiza libros en lista/tarjeta, con filtros y paginación.
   - Detalle de libro, edición, alta/baja mediante formularios reutilizables.
   - Backend: `ProductController.cs`, `ProductService.cs`.
   - **Presente:** Sí. Validar que los formularios incluyan todas las validaciones del PRD.
   - **Reglas aplicadas:** Reutilización de formularios, validaciones, pruebas unitarias, documentación de cambios.

5. **Gestión de Clientes**
   - Accede a la gestión de clientes (`src/app/components/customers/customers.component.ts`).
   - Visualiza lista, historial de compras, edición de datos.
   - Backend: `CustomerController.cs`, `CustomerService.cs`.
   - **Presente:** Sí. Revisar que los endpoints y formularios cubran todos los campos requeridos.
   - **Reglas aplicadas:** Modularidad, pruebas de endpoints, documentación técnica, validaciones.

6. **Gestión de Perfil**
   - Accede a su perfil (`src/app/components/settings/settings.component.ts`).
   - Edita datos personales, cambia contraseña, cambia idioma (`app-translation.service.ts`).
   - **Presente:** Sí. Revisar integración con ngx-translate y validaciones.
   - **Reglas aplicadas:** Multilenguaje, accesibilidad, pruebas de formularios, documentación de cambios.

7. **Compra de Libros (Simulación)**
   - Puede simular compra de libros (`src/app/components/orders/orders.component.ts`).
   - Selecciona libros, agrega al carrito, completa formulario de compra.
   - Backend: `OrderController.cs`, `OrdersService.cs`.
   - **Presente:** Sí. Validar que el flujo cubra todos los pasos del PRD.
   - **Reglas aplicadas:** Pruebas de flujo, validaciones, documentación de endpoints.

8. **Historial de Compras**
   - Consulta historial de compras de cualquier cliente (`orders.component.ts`, `customers.component.ts`).
   - Ve detalles, descarga comprobantes.
   - **Presente:** Sí. Revisar que los detalles sean completos y exportables.
   - **Reglas aplicadas:** Pruebas de exportación, documentación de historial, modularidad.

9. **Interfaz Responsiva y Multilenguaje**
   - Bootstrap 5 y ngx-translate garantizan responsividad e idiomas.
   - **Presente:** Sí. Validar que todos los textos estén traducidos y la interfaz sea adaptable.
   - **Reglas aplicadas:** Accesibilidad, pruebas de responsividad, documentación de idiomas.

10. **Gestión de Roles y Usuarios**
   - El administrador puede gestionar roles y usuarios, incluyendo la creación, edición, asignación de permisos y eliminación, utilizando los componentes ya implementados (`roles-management.component.ts`, `role-editor.component.ts`, `users-management.component.ts`) y los servicios correspondientes. Esta gestión sigue el mismo flujo visual y funcional que el resto de entidades, aprovechando la interfaz y validaciones ya diseñadas.
   - **Presente:** Sí. Asegurarse de que la gestión de usuarios y roles esté correctamente integrada y documentada.
   - **Reglas aplicadas:** Modularidad, reutilización, validaciones, pruebas unitarias, documentación de cambios.

---

## Rol: Cliente

### Flujo: Uso Personal de la Plataforma

1. **Inicio de Sesión**
   - Pantalla de login (`login.component.ts`).
   - Servicios de autenticación (`auth.service.ts`).
   - **Presente:** Sí.
   - **Reglas aplicadas:** Encabezado, autenticación JWT/OIDC, pruebas unitarias.

2. **Navegación por el Menú**
   - Menú lateral/superior con acceso a Catálogo, Historial, Dashboard, Perfil.
   - Guards y permisos para Cliente.
   - **Presente:** Sí. Validar visibilidad de opciones.
   - **Reglas aplicadas:** Modularidad, restricción por rol, pruebas de navegación.

3. **Visualización del Dashboard Personal**
   - Dashboard personal (`statistics-demo.component.ts`).
   - KPIs y gráficas.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Personalización, pruebas de componentes.

4. **Catálogo de Libros**
   - Catálogo (`products.component.ts`).
   - Filtros, paginación, detalle de libro.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Reutilización, validaciones, pruebas unitarias.

5. **Compra de Libros**
   - Carrito y compra (`orders.component.ts`).
   - Formulario de compra, validaciones.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Pruebas de flujo, validaciones.

6. **Historial de Compras**
   - Historial (`orders.component.ts`).
   - Detalles, descarga de comprobantes.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Pruebas de exportación, documentación de historial.

7. **Gestión de Perfil**
   - Perfil (`settings.component.ts`).
   - Edición de datos, cambio de contraseña, idioma.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Multilenguaje, accesibilidad, pruebas de formularios.

8. **Interfaz Responsiva y Multilenguaje**
   - Bootstrap y ngx-translate.
   - **Presente:** Sí.
   - **Reglas aplicadas:** Accesibilidad, pruebas de responsividad.

---

### Mejoras en el Flujo del Cliente

1. **Creación de cuenta (registro de cliente)**
   - El cliente puede registrarse desde la pantalla de login. Se añade una opción "Crear cuenta" que abre un formulario de registro con campos requeridos (nombre, correo electrónico, contraseña, confirmación de contraseña, teléfono, dirección). El sistema valida los datos, muestra mensajes de éxito o error y redirige al login tras el registro exitoso.

2. **Notificaciones para el cliente**
   - El cliente visualiza notificaciones relevantes (compras, promociones, avisos) mediante el componente existente de notificaciones. Las notificaciones se muestran en el dashboard o menú principal y se gestionan con los servicios actuales.

3. **Favoritos o lista de deseos**
   - El cliente puede marcar libros como favoritos desde el catálogo y consultar su lista de favoritos en el perfil o menú. La funcionalidad reutiliza componentes y servicios existentes para persistir la lista.

4. **Sección de ayuda o soporte**
   - Se incorpora una sección de ayuda accesible desde el menú principal, donde el cliente puede consultar preguntas frecuentes y datos de contacto. Se reutilizan estilos y estructura de componentes informativos.

5. **Promociones y recomendaciones**
   - Las promociones y productos recomendados se muestran en el dashboard o catálogo, utilizando el banner existente para destacar ofertas y filtrando productos recomendados según el historial de compras.

6. **Accesibilidad avanzada**
   - Se añaden opciones de alto contraste y tamaño de fuente en la gestión de perfil, permitiendo al cliente personalizar la accesibilidad desde el perfil y persistiendo las preferencias con los servicios actuales.

---

## Cumplimiento y Recomendaciones

- Todas las funcionalidades del PRD que pueden ser cubiertas por el frontend actual están presentes en la solución y alineadas con las reglas de codificación y documentación.
- Se recomienda:
  - Validar que los guards y permisos estén correctamente configurados para cada rol.
  - Revisar que los formularios incluyan todas las validaciones requeridas.
  - Verificar que los endpoints y servicios cubran todos los campos y flujos del PRD.
  - Asegurar que la internacionalización y responsividad estén implementadas en todos los componentes.
  - Documentar en cada componente la relación con los requerimientos del PRD y las reglas del proyecto para facilitar el mantenimiento.

*No se incluyen reportes con Crystal Reports ni control de versiones, siguiendo las indicaciones.*

---

## Estructura Detallada del Frontend

### Componentes Principales (ubicación: `src/app/components/`)
- **about/about.component.ts**: Pantalla "Acerca de".
- **controls/banner-demo.component.ts**: Banner demostrativo.
- **controls/notifications-viewer.component.ts**: Visualización de notificaciones.
- **controls/role-editor.component.ts**: Editor de roles.
- **controls/roles-management.component.ts**: Gestión de roles.
- **controls/search-box.component.ts**: Caja de búsqueda reutilizable.
- **controls/statistics-demo.component.ts**: Panel de KPIs y gráficas (dashboard).
- **customers/customers.component.ts**: Gestión y visualización de clientes.
- **home/home.component.ts**: Pantalla principal de bienvenida.
- **login/login.component.ts**: Pantalla de inicio de sesión.
- **not-found/not-found.component.ts**: Página de error 404.
- **orders/orders.component.ts**: Gestión y visualización de compras/pedidos.
- **products/products.component.ts**: Catálogo y gestión de libros/productos.
- **settings/settings.component.ts**: Gestión de perfil, idioma y configuración.

### Servicios Principales (ubicación: `src/app/services/`)
- **account-endpoint.service.ts**: Comunicación con API de cuentas.
- **account.service.ts**: Lógica de autenticación y usuarios.
- **alert.service.ts**: Notificaciones y alertas.
- **app-title.service.ts**: Gestión del título de la app.
- **app-translation.service.ts**: Traducción y multilenguaje.
- **auth-guard.ts**: Protección de rutas por autenticación y roles.
- **auth.service.ts**: Manejo de tokens, login y roles.
- **configuration.service.ts**: Parámetros de configuración.
- **endpoint-base.service.ts**: Base para servicios HTTP.
- **jwt-helper.ts**: Utilidades para JWT.
- **local-store-manager.service.ts**: Almacenamiento local.
- **notification-endpoint.service.ts**: Comunicación con API de notificaciones.
- **notification.service.ts**: Lógica de notificaciones.
- **oidc-helper.service.ts**: Utilidades OIDC/OAuth2.
- **theme-manager.ts**: Gestión de temas visuales.
- **utilities.ts**: Utilidades generales.

### Módulo Principal
- **app.module.ts**: Módulo raíz de la aplicación Angular.
- **app.config.ts**: Configuración global de providers, interceptores, animaciones, traducción, etc.

### Rutas y Navegación (ubicación: `src/app/app.routes.ts`)
- **Definición de rutas principales:**
  - `/` ? HomeComponent (protegida por AuthGuard)
  - `/login` ? LoginComponent
  - `/customers` ? CustomersComponent (protegida por AuthGuard)
  - `/products` ? ProductsComponent (protegida por AuthGuard)
  - `/orders` ? OrdersComponent (protegida por AuthGuard)
  - `/settings` ? SettingsComponent (protegida por AuthGuard)
  - `/about` ? AboutComponent
  - `/home` ? Redirección a `/`
  - `**` ? NotFoundComponent
- **Protección de rutas:**
  - Se usa `AuthGuard` para proteger rutas que requieren autenticación y roles.
  - La visibilidad de opciones en el menú depende de los permisos del usuario (verificado en `app.component.ts`).

### Esquema de Navegación
- Menú principal en `app.component.html` muestra opciones según el rol y permisos.
- El router-outlet renderiza el componente correspondiente según la ruta activa.
- Las rutas protegidas requieren autenticación y permisos específicos.

---

## Especificación de APIs Backend

A continuación se detallan los principales endpoints disponibles en la solución, incluyendo rutas, métodos, parámetros, ejemplos de request/response y reglas de autorización por endpoint.

### 1. Autenticación y Autorización
- **POST /connect/token**
  - Solicita token JWT vía OpenID Connect.
  - Parámetros: username, password (grant_type=password) o refresh_token (grant_type=refresh_token).
  - Ejemplo request:
    ```json
    { "grant_type": "password", "username": "admin", "password": "1234" }
    ```
  - Response: JWT y claims de usuario.
  - **Roles:** Todos (según credenciales válidas).

### 2. Gestión de Productos (Libros)
- **GET /api/product**
  - Obtiene todos los productos.
  - Response: List<ProductVM>
  - **Roles:** Administrador, Vendedor, Cliente

- **GET /api/product/{id}**
  - Obtiene producto por ID.
  - Parámetro: id (int)
  - Response: ProductVM
  - **Roles:** Administrador, Vendedor, Cliente

- **POST /api/product**
  - Crea nuevo producto.
  - Body: ProductVM
  - Response: ProductVM creado
  - **Roles:** Administrador

- **PUT /api/product/{id}**
  - Actualiza producto existente.
  - Parámetro: id (int), Body: ProductVM
  - Response: ProductVM actualizado
  - **Roles:** Administrador

- **DELETE /api/product/{id}**
  - Elimina producto por ID.
  - Parámetro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 3. Gestión de Categorías
- **GET /api/category**
  - Obtiene todas las categorías.
  - Response: List<ProductCategory>
  - **Roles:** Administrador, Vendedor, Cliente

- **POST /api/category**
  - Crea nueva categoría.
  - Body: ProductCategory
  - Response: ProductCategory creado
  - **Roles:** Administrador

- **PUT /api/category/{id}**
  - Actualiza categoría existente.
  - Parámetro: id (int), Body: ProductCategory
  - Response: ProductCategory actualizado
  - **Roles:** Administrador

- **DELETE /api/category/{id}**
  - Elimina categoría por ID.
  - Parámetro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 4. Gestión de Clientes
- **GET /api/customer**
  - Obtiene todos los clientes.
  - Response: List<CustomerVM>
  - **Roles:** (No protegido por roles, revisar para producción)

- **GET /api/customer/{id}**
  - Obtiene cliente por ID.
  - Parámetro: id (int)
  - Response: CustomerVM
  - **Roles:** (No protegido por roles, revisar para producción)

- **POST /api/customer**
  - Crea nuevo cliente.
  - Body: CustomerVM
  - Response: CustomerVM creado
  - **Roles:** (No protegido por roles, revisar para producción)

- **PUT /api/customer/{id}**
  - Actualiza cliente existente.
  - Parámetro: id (int), Body: CustomerVM
  - Response: CustomerVM actualizado
  - **Roles:** (No protegido por roles, revisar para producción)

- **DELETE /api/customer/{id}**
  - Elimina cliente por ID.
  - Parámetro: id (int)
  - Response: NoContent
  - **Roles:** (No protegido por roles, revisar para producción)

### 5. Gestión de Ventas (Órdenes)
- **GET /api/order**
  - Obtiene todas las ventas/órdenes.
  - Response: List<OrderVM>
  - **Roles:** Administrador, Vendedor

- **POST /api/order**
  - Crea nueva venta/orden.
  - Body: OrderVM
  - Response: OrderVM creado
  - **Roles:** Administrador, Vendedor

- **PUT /api/order/{id}**
  - Actualiza venta/orden existente.
  - Parámetro: id (int), Body: OrderVM
  - Response: OrderVM actualizado
  - **Roles:** Administrador, Vendedor

- **DELETE /api/order/{id}**
  - Elimina venta/orden por ID.
  - Parámetro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 6. Gestión de Proveedores
- **GET /api/proveedor**
  - Obtiene todos los proveedores.
  - Response: List<Proveedor>
  - **Roles:** Administrador

- **POST /api/proveedor**
  - Crea nuevo proveedor.
  - Body: Proveedor
  - Response: Proveedor creado
  - **Roles:** Administrador

- **PUT /api/proveedor/{id}**
  - Actualiza proveedor existente.
  - Parámetro: id (int), Body: Proveedor
  - Response: Proveedor actualizado
  - **Roles:** Administrador

- **DELETE /api/proveedor/{id}**
  - Elimina proveedor por ID.
  - Parámetro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 7. Gestión de Usuarios (Cuenta)
- **GET /api/account/users/me**
  - Obtiene datos del usuario actual.
  - Response: UserVM
  - **Roles:** Usuario autenticado

- **GET /api/account/users/{id}**
  - Obtiene usuario por ID.
  - Parámetro: id (string)
  - Response: UserVM
  - **Roles:** Usuario autenticado con permiso de lectura

- **GET /api/account/users**
  - Obtiene todos los usuarios.
  - Response: List<UserVM>
  - **Roles:** Administrador (ViewAllUsersPolicy)

- **POST /api/account/users**
  - Crea nuevo usuario.
  - Body: UserEditVM
  - Response: UserVM creado
  - **Roles:** Administrador (ManageAllUsersPolicy)

- **PUT /api/account/users/{id}**
  - Actualiza usuario existente.
  - Parámetro: id (string), Body: UserEditVM
  - Response: NoContent
  - **Roles:** Usuario autenticado con permiso de actualización

- **DELETE /api/account/users/{id}**
  - Elimina usuario por ID.
  - Parámetro: id (string)
  - Response: UserVM eliminado
  - **Roles:** Usuario autenticado con permiso de eliminación

---

## 8. Configuraciones y Entornos

### Archivos de Configuración Principales

**Backend (.NET 9 / ASP.NET Core):**
- `appsettings.json` y `appsettings.Development.json`
  - Definen cadenas de conexión a la base de datos, configuración SMTP para correo, parámetros de OIDC, logging y hosts permitidos.
  - Ejemplo de configuración:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(local);Database=Proyecto_Final_Progra_6;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true"
      },
      "SmtpConfig": {
        "Host": "mail.example.com",
        "Port": 25,
        "UseSSL": false,
        "Name": "QuickApp Template",
        "Username": "your@email.com",
        "EmailAddress": "your@email.com",
        "Password": "YourPassword"
      },
      "OIDC": {
        "Certificates": {
          "Path": "",
          "Password": ""
        }
      },
      "Logging": {
        "PathFormat": "Logs/log-{Date}.log",
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```
  - **Variables relevantes:**
    - `DefaultConnection`: Cadena de conexión SQL Server.
    - `SmtpConfig`: Parámetros para envío de correos (host, usuario, contraseña, puerto, SSL).
    - `OIDC.Certificates`: Ruta y contraseña de certificados para autenticación OIDC.
    - `Logging`: Ruta y nivel de logs.
    - `AllowedHosts`: Hosts permitidos para la API.

**Frontend (Angular 19):**
- `src/environments/environment.ts` y `environment.prod.ts`
  - Configuran variables de entorno para desarrollo y producción.
  - Ejemplo:
    ```typescript
    export const environment: Environment = {
      production: false,
      baseUrl: "https://localhost:7085",
      fallbackBaseUrl: "https://quickapp.azurewebsites.net"
    };
    ```
  - **Variables relevantes:**
    - `production`: Indica si la app está en modo producción.
    - `baseUrl`: URL base del servidor API (desarrollo: local, producción: host actual).
    - `fallbackBaseUrl`: URL alternativa si el API local no está disponible.

- `src/app/app.config.ts`
  - Configura providers globales, rutas, animaciones, traducción, interceptores HTTP y manejo de errores.

- `src/app/services/configuration.service.ts`
  - Permite gestionar configuraciones de usuario (idioma, tema, URL de inicio, visibilidad de paneles) y persistirlas en localStorage.

### Endpoints de API

- **Backend principal:**
  - Desarrollo: `https://localhost:7085`
  - Producción: Host actual o configurado en `baseUrl`
  - Respaldo: `https://quickapp.azurewebsites.net` (recomendado actualizar a instancia propia)

- **Endpoints REST principales:**
  - Autenticación: `/connect/token`
  - Productos: `/api/product`, `/api/product/{id}`
  - Categorías: `/api/category`, `/api/category/{id}`
  - Clientes: `/api/customer`, `/api/customer/{id}`
  - Órdenes: `/api/order`, `/api/order/{id}`
  - Proveedores: `/api/proveedor`, `/api/proveedor/{id}`
  - Usuarios: `/api/account/users`, `/api/account/users/{id}`, `/api/account/users/me`

### Claves y Variables de Seguridad

- **SMTP:**
  - Usuario y contraseña para envío de correos definidos en `appsettings.json` (`SmtpConfig`).
- **Certificados OIDC:**
  - Ruta y contraseña para certificados de autenticación (`OIDC.Certificates`).
- **Tokens JWT/OIDC:**
  - Gestionados en frontend por `auth.service.ts` y en backend por OpenIddict y ASP.NET Core Identity.

### Configuración de Logging

- **Ruta de logs:**
  - `Logs/log-{Date}.log` (configurable en `appsettings.json`)
- **Niveles de log:**
  - `Information` por defecto, `Warning` para ASP.NET Core.

### Configuración de Internacionalización y Temas

- **Idioma:**
  - Configurable por usuario, persistido en localStorage (`configuration.service.ts`).
- **Tema visual:**
  - Seleccionable por usuario, persistido en localStorage.

### Resumen

La solución utiliza archivos de configuración separados para desarrollo y producción, variables de entorno en Angular, endpoints REST bien definidos y claves para correo y autenticación. Las configuraciones de usuario (idioma, tema, paneles) se gestionan y persisten en el frontend. Los endpoints y claves sensibles deben ser protegidos y actualizados antes de despliegue en producción.

---

## Modelos de Datos

A continuación se describe la estructura de los modelos principales utilizados en el backend (C#) y frontend (TypeScript), incluyendo sus propiedades, tipos, relaciones y validaciones relevantes.

### Backend (.NET 9 / C#)

#### Cliente
```csharp
public class Cliente : IAuditableEntity {
    public int Id { get; set; }
    public string Nombre { get; set; } // Requerido, máx. 100
    public string? Email { get; set; } // Máx. 100
    public string? Telefono { get; set; } // Máx. 30
    public string? Direccion { get; set; } // Máx. 200
    public ICollection<Venta> Ventas { get; set; }
    // Auditoría: CreatedBy, CreatedDate, UpdatedBy, UpdatedDate
}
```

#### Libro
```csharp
public class Libro : IAuditableEntity {
    public int Id { get; set; }
    public string Titulo { get; set; } // Requerido
    public string Autor { get; set; } // Requerido
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public int? ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
    public ICollection<VentaDetalle> VentaDetalles { get; set; }
    // Auditoría
}
```

#### Categoria
```csharp
public class Categoria : IAuditableEntity {
    public int Id { get; set; }
    public string Nombre { get; set; } // Requerido
    public string? Descripcion { get; set; }
    public ICollection<Libro> Libros { get; set; }
    // Auditoría
}
```

#### Venta y VentaDetalle
```csharp
public class Venta : IAuditableEntity {
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public ICollection<VentaDetalle> Detalles { get; set; }
    // Auditoría
}
public class VentaDetalle {
    public int Id { get; set; }
    public int VentaId { get; set; }
    public Venta Venta { get; set; }
    public int LibroId { get; set; }
    public Libro Libro { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}
```

#### Validaciones Backend
- Campos requeridos: `Nombre`, `Titulo`, `Autor`.
- Máximos: `Nombre` (100), `Email` (100), `Telefono` (30), `Direccion` (200), `Descripcion` (500), `Icon` (256).
- Relaciones: Cliente-Venta, Libro-Categoria, Libro-Proveedor, Venta-VentaDetalle.
- Validaciones adicionales implementadas con FluentValidation y DataAnnotations.

### Frontend (TypeScript)

#### User
```typescript
export class User {
  id = '';
  userName = '';
  fullName = '';
  email = '';
  jobTitle = '';
  phoneNumber = '';
  roles: string[] = [];
  isEnabled = true;
  isLockedOut = false;
}
```

#### Role
```typescript
export class Role {
  id = '';
  name = '';
  description = '';
  permissions: Permission[] = [];
  usersCount = 0;
}
```

#### Permission
```typescript
export interface Permission {
  name: string;
  value: string;
  groupName: string;
  description: string;
}
```

#### LoginResponse / IdToken
```typescript
export interface LoginResponse {
  id_token: string;
  access_token: string;
  refresh_token: string;
  expires_in: number;
  token_type: string;
  scope: string;
}
export interface IdToken {
  iat: number;
  exp: number;
  iss: string;
  aud: string | string[];
  sub: string;
  role: string | string[];
  permission: string | string[];
  name: string;
  email: string;
  phone_number: string;
  fullname: string;
  jobtitle: string;
  configuration: string;
}
```

#### Notification
```typescript
export class Notification {
  id = 0;
  header = '';
  body = '';
  date = new Date();
  isRead = false;
  isPinned = false;
}
```

#### Validaciones Frontend
- Validaciones de formularios: campos requeridos, formato de email, longitud máxima/minima, coincidencia de contraseñas, etc.
- Validaciones adicionales implementadas con Angular Forms y validadores personalizados.

---

## Flujos de Negocio y Validaciones

### Reglas de Negocio Específicas
- **Lógica de Stock:**
  - No se permite la venta de libros si el stock es insuficiente.
  - Al registrar una venta, se descuenta automáticamente el stock del libro vendido.
  - El sistema alerta cuando el stock de un libro es bajo (umbral configurable).
- **Restricciones de Edición y Eliminación:**
  - Solo usuarios con rol Administrador pueden editar o eliminar productos, categorías, clientes y proveedores.
  - Los clientes solo pueden editar su propio perfil y consultar su historial de compras.
  - Los vendedores pueden registrar ventas y consultar inventario, pero no modificar productos.
- **Cálculos de KPIs y Dashboard:**
  - KPIs principales: ventas del día, productos más vendidos, stock bajo, total de ingresos.
  - Los KPIs se calculan en tiempo real y se muestran en el dashboard mediante gráficas (ng2-charts, chart.js).
  - Los reportes permiten filtrar por fecha, cliente, categoría y exportar a PDF.
- **Reportes:**
  - Reporte de ventas por periodo y de inventario bajo.
  - Acceso a reportes protegido por roles.

### Validaciones en Formularios y Backend
- **Backend (ASP.NET Core / FluentValidation):**
  - Validación de campos obligatorios (`Nombre`, `Titulo`, `Autor`, etc.).
  - Validación de formatos (email, teléfono, fechas).
  - Restricción de valores mínimos y máximos (stock, precio, longitud de texto).
  - Validación de relaciones (no se puede eliminar una categoría si tiene libros asociados).
  - Uso de `ModelState.IsValid` y validadores personalizados para cada entidad.
- **Frontend (Angular Forms):**
  - Formularios reactivos con validaciones en tiempo real.
  - Campos obligatorios, formato de email, longitud máxima/mínima, coincidencia de contraseñas.
  - Mensajes de error claros y accesibles en la interfaz.
  - Validaciones adicionales mediante directivas y validadores personalizados.

---

## Gestión de Errores y Mensajes

### Mensajes de Error y Éxito Estandarizados
- **Backend:**
  - Respuestas de error: `BadRequest`, `NotFound`, `Unauthorized`, `ValidationProblem`, con mensajes claros y consistentes.
  - Respuestas de éxito: `Ok`, `CreatedAtAction`, `NoContent`, incluyendo detalles relevantes en el cuerpo JSON.
  - Ejemplo de error: `return BadRequest(ModelState);` o `return NotFound("Producto no encontrado");`
  - Ejemplo de éxito: `return Ok(productoVM);`
- **Frontend:**
  - Uso de `AlertService` para mostrar mensajes de éxito, error, advertencia y espera.
  - Métodos: `showMessage`, `showStickyMessage`, `showDialog` para notificaciones y diálogos.
  - Severidad estandarizada: `info`, `success`, `error`, `warn`, `wait`.
  - Mensajes accesibles y traducibles (multilenguaje).

### Flujos de Manejo de Errores
- **Backend:**
  - Validación de datos con `ModelState.IsValid` y `FluentValidation`.
  - Manejo de excepciones con `try/catch` y clases personalizadas (`CustomerException`, etc.).
  - Registro de errores críticos en logs (`ILogger`).
  - Envío de mensajes de error estructurados al frontend.
- **Frontend:**
  - Captura de errores HTTP con interceptores y servicios base (`EndpointBase.handleError`).
  - Redirección automática en caso de expiración de sesión o error crítico (`AuthService.reLogin`).
  - Notificación al usuario mediante `AlertService` y mensajes contextuales.
  - Manejo global de errores con `AppErrorHandler` (recarga de página ante error fatal).

---

## Pruebas y Criterios de Aceptación

### Casos de Prueba Esperados por Funcionalidad
- **Autenticación y Seguridad:**
  - Prueba de login con credenciales válidas e inválidas.
  - Prueba de recuperación y cambio de contraseña.
  - Prueba de acceso a rutas protegidas según rol.
- **Gestión de Entidades (CRUD):**
  - Crear, consultar, modificar y eliminar libros, categorías, ventas, clientes y proveedores.
  - Validación de datos obligatorios y formatos.
  - Prueba de relaciones entre entidades (ej: no eliminar categoría con libros asociados).
- **Dashboard y KPIs:**
  - Visualización de KPIs (ventas del día, stock bajo, productos más vendidos).
  - Actualización en tiempo real de gráficas y paneles.
- **Reportes:**
  - Generación de reportes de ventas por periodo y de inventario bajo.
  - Prueba de filtros por fecha, cliente, categoría y exportación a PDF.
  - Prueba de acceso restringido a reportes por rol.
- **Gestión de Usuarios y Roles:**
  - Creación y asignación de roles.
  - Restricción de vistas y acciones según rol.
- **Interfaz Web:**
  - Prueba de responsividad en diferentes dispositivos.
  - Validación de formularios reactivos y mensajes de error.
  - Prueba de cambio de idioma y traducción de textos.
- **Consumo de APIs:**
  - Prueba de operaciones CRUD y reportes vía servicios HTTP.
  - Prueba de manejo de tokens JWT y protección de rutas.
- **Internacionalización y Accesibilidad:**
  - Prueba de cambio de idioma en tiempo real.
  - Prueba de accesibilidad en formularios y navegación.

### Criterios para Considerar una Funcionalidad como “Terminada”
- Cumple con todos los requisitos funcionales y técnicos definidos en el PRD.
- Pasa todas las pruebas unitarias y de integración (Jasmine/Karma para Angular, xUnit para .NET).
- La interfaz es responsiva y usable en diferentes dispositivos.
- La seguridad y protección de datos están garantizadas.
- Los reportes son funcionales y exportables.
- La documentación técnica y de usuario está actualizada y disponible.
- El código está versionado y documentado según las reglas del proyecto.
- No existen errores críticos ni advertencias en el sistema.

---

## Guía de Estilos y UX

### Paleta de Colores
- El sistema utiliza temas Bootswatch (ej. Flatly, Minty, Superhero, Solar, Cerulean) basados en Bootstrap 5 y SASS.
- Colores principales: `$primary`, `$secondary`, `$success`, `$info`, `$warning`, `$danger`, `$light`, `$dark`.
- Cada tema define variantes y escalas de color para fondos, textos, botones y alertas.
- Ejemplo de paletas:
  - Flatly: Azul claro, gris, blanco, acentos en verde y naranja.
  - Minty: Verde menta, blanco, gris claro, acentos en azul.
  - Superhero: Azul oscuro, gris, blanco, acentos en rojo y amarillo.

### Tipografía
- Fuentes principales: Lato, Montserrat (importadas vía Google Fonts en los temas).
- Tamaños y pesos adaptados para títulos, textos, menús y botones.
- Uso de clases Bootstrap para encabezados, textos y botones.

### Iconografía
- Iconos FontAwesome y Material Icons integrados en componentes y formularios.
- Iconos para acciones principales: editar, eliminar, agregar, buscar, notificar, usuario, etc.
- Iconos accesibles y escalables.

### Layout
- Estructura SPA con Angular 19 y Bootstrap 5.
- Layout responsivo: menús laterales/superiores, paneles, tarjetas, tablas y formularios adaptables.
- Uso de clases y utilidades Bootstrap para grid, espaciado, alineación y visibilidad.
- Paneles de dashboard y KPIs con ng2-charts/chart.js.

### Reglas de Diseño Responsivo y Accesibilidad
- Interfaz completamente responsiva, adaptada a móviles, tablets y escritorio.
- Uso de utilidades Bootstrap y media queries para adaptar el layout.
- Formularios y componentes accesibles: etiquetas, roles ARIA, navegación por teclado.
- Soporte multilenguaje con ngx-translate.
- Contraste adecuado y tamaños de fuente legibles.
- Mensajes y notificaciones accesibles y visibles.
- Pruebas de accesibilidad y responsividad incluidas en los criterios de aceptación.

---

**Notas:**
- Todos los endpoints que requieren autenticación y roles usan `[Authorize]` y/o `[Authorize(Roles = ...)]`.
- Los endpoints de clientes no están protegidos por roles en el código actual, se recomienda agregar protección antes de producción.
- Los endpoints devuelven respuestas en formato JSON.
- Para detalles adicionales y pruebas, consultar la documentación Swagger en `/swagger`.
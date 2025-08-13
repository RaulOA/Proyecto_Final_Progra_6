# Historias de Usuario Ultra Detalladas: Admin y Cliente

---

## Introducci�n y Contexto

Este documento describe historias de usuario ultra detalladas para los roles Admin y Cliente, alineadas con los requerimientos funcionales del PRD y la estructura actual del sistema. Adem�s, integra las reglas de codificaci�n, documentaci�n y buenas pr�cticas del proyecto para asegurar calidad, coherencia y mantenibilidad.

Cada paso indica:
- Qu� hace el usuario
- Qu� ve en la interfaz (seg�n los componentes y servicios existentes)
- Qu� acciones ejecuta y qu� ocurre despu�s
- D�nde se encuentran las funcionalidades en la soluci�n actual
- Si la funcionalidad est� presente, y si requiere ajustes para encajar en la estructura
- Qu� reglas y buenas pr�cticas aplican en cada flujo

---

## Reglas de Codificaci�n, Documentaci�n y Buenas Pr�cticas

- Todos los archivos deben incluir encabezado con autor, nombre, soluci�n, proyecto, ruta, prop�sito, historial de cambios y alertas cr�ticas.
- Los comentarios descriptivos deben estar en espa�ol y ubicados junto a la secci�n relevante.
- Mantener la coherencia visual y funcional, modularidad y separaci�n de responsabilidades.
- Priorizar la reutilizaci�n de componentes, servicios y estilos existentes.
- No romper la estructura de carpetas y archivos definida por la plantilla base.
- Documentar cambios relevantes y mantener la documentaci�n t�cnica actualizada.
- Escribir y ejecutar pruebas unitarias e integraci�n (Jasmine/Karma para Angular, pruebas de endpoints en backend).
- Ejecutar an�lisis est�tico de c�digo (ESLint/angular-eslint para frontend).
- Usar @ngx-translate/core para multilenguaje y asegurar accesibilidad y responsividad.
- Implementar autenticaci�n y autorizaci�n basada en JWT, OIDC/OAuth2 y ASP.NET Core Identity.
- Restringir vistas y acciones seg�n el tipo de usuario (Admin, Cliente).
- Usar servicios Angular para consumir endpoints CRUD y reportes, con interceptores para JWT y protecci�n de rutas.
- Personalizar la interfaz, men�s y dashboard para la tem�tica de librer�a.
- Mantener la coherencia visual y funcional en toda la aplicaci�n.

---

## Rol: Admin

### Flujo: Gesti�n Completa del Sistema

1. **Inicio de Sesi�n**
   - El Admin accede a la pantalla de login (`src/app/components/login/login.component.ts`).
   - Ingresa usuario/correo y contrase�a.
   - El sistema valida credenciales usando servicios de autenticaci�n (`src/app/services/auth.service.ts`, backend: `AuthorizationController.cs`).
   - Si son v�lidas, accede al panel principal; si no, ve mensajes de error.
   - **Presente:** S�. No requiere ajuste.
   - **Reglas aplicadas:** Encabezado, comentarios, autenticaci�n JWT/OIDC, pruebas unitarias, documentaci�n t�cnica.

2. **Navegaci�n por el Men�**
   - Ve un men� lateral o superior (`src/app/components/controls/menu.component.ts` o similar) con acceso a Cat�logo, Dashboard, Gesti�n de Clientes, Gesti�n de Libros, Perfil.
   - Las opciones visibles corresponden a su rol, gestionadas por guards (`src/app/services/auth-guard.ts`).
   - **Presente:** S�. Revisar que los guards y permisos est�n correctamente configurados para Admin.
   - **Reglas aplicadas:** Modularidad, reutilizaci�n, restricci�n por rol, comentarios, pruebas de navegaci�n.

3. **Visualizaci�n del Dashboard**
   - Accede al dashboard informativo (`src/app/components/controls/statistics-demo.component.ts`).
   - Ve KPIs y gr�ficas (ng2-charts, chart.js).
   - El panel es responsivo (Bootstrap 5).
   - **Presente:** S�. Revisar que los datos mostrados sean los requeridos por el PRD.
   - **Reglas aplicadas:** Personalizaci�n, coherencia visual, pruebas de componentes, documentaci�n de KPIs.

4. **Gesti�n de Libros**
   - Accede al cat�logo de libros (`src/app/components/products/products.component.ts`).
   - Visualiza libros en lista/tarjeta, con filtros y paginaci�n.
   - Detalle de libro, edici�n, alta/baja mediante formularios reutilizables.
   - Backend: `ProductController.cs`, `ProductService.cs`.
   - **Presente:** S�. Validar que los formularios incluyan todas las validaciones del PRD.
   - **Reglas aplicadas:** Reutilizaci�n de formularios, validaciones, pruebas unitarias, documentaci�n de cambios.

5. **Gesti�n de Clientes**
   - Accede a la gesti�n de clientes (`src/app/components/customers/customers.component.ts`).
   - Visualiza lista, historial de compras, edici�n de datos.
   - Backend: `CustomerController.cs`, `CustomerService.cs`.
   - **Presente:** S�. Revisar que los endpoints y formularios cubran todos los campos requeridos.
   - **Reglas aplicadas:** Modularidad, pruebas de endpoints, documentaci�n t�cnica, validaciones.

6. **Gesti�n de Perfil**
   - Accede a su perfil (`src/app/components/settings/settings.component.ts`).
   - Edita datos personales, cambia contrase�a, cambia idioma (`app-translation.service.ts`).
   - **Presente:** S�. Revisar integraci�n con ngx-translate y validaciones.
   - **Reglas aplicadas:** Multilenguaje, accesibilidad, pruebas de formularios, documentaci�n de cambios.

7. **Compra de Libros (Simulaci�n)**
   - Puede simular compra de libros (`src/app/components/orders/orders.component.ts`).
   - Selecciona libros, agrega al carrito, completa formulario de compra.
   - Backend: `OrderController.cs`, `OrdersService.cs`.
   - **Presente:** S�. Validar que el flujo cubra todos los pasos del PRD.
   - **Reglas aplicadas:** Pruebas de flujo, validaciones, documentaci�n de endpoints.

8. **Historial de Compras**
   - Consulta historial de compras de cualquier cliente (`orders.component.ts`, `customers.component.ts`).
   - Ve detalles, descarga comprobantes.
   - **Presente:** S�. Revisar que los detalles sean completos y exportables.
   - **Reglas aplicadas:** Pruebas de exportaci�n, documentaci�n de historial, modularidad.

9. **Interfaz Responsiva y Multilenguaje**
   - Bootstrap 5 y ngx-translate garantizan responsividad e idiomas.
   - **Presente:** S�. Validar que todos los textos est�n traducidos y la interfaz sea adaptable.
   - **Reglas aplicadas:** Accesibilidad, pruebas de responsividad, documentaci�n de idiomas.

10. **Gesti�n de Roles y Usuarios**
   - El administrador puede gestionar roles y usuarios, incluyendo la creaci�n, edici�n, asignaci�n de permisos y eliminaci�n, utilizando los componentes ya implementados (`roles-management.component.ts`, `role-editor.component.ts`, `users-management.component.ts`) y los servicios correspondientes. Esta gesti�n sigue el mismo flujo visual y funcional que el resto de entidades, aprovechando la interfaz y validaciones ya dise�adas.
   - **Presente:** S�. Asegurarse de que la gesti�n de usuarios y roles est� correctamente integrada y documentada.
   - **Reglas aplicadas:** Modularidad, reutilizaci�n, validaciones, pruebas unitarias, documentaci�n de cambios.

---

## Rol: Cliente

### Flujo: Uso Personal de la Plataforma

1. **Inicio de Sesi�n**
   - Pantalla de login (`login.component.ts`).
   - Servicios de autenticaci�n (`auth.service.ts`).
   - **Presente:** S�.
   - **Reglas aplicadas:** Encabezado, autenticaci�n JWT/OIDC, pruebas unitarias.

2. **Navegaci�n por el Men�**
   - Men� lateral/superior con acceso a Cat�logo, Historial, Dashboard, Perfil.
   - Guards y permisos para Cliente.
   - **Presente:** S�. Validar visibilidad de opciones.
   - **Reglas aplicadas:** Modularidad, restricci�n por rol, pruebas de navegaci�n.

3. **Visualizaci�n del Dashboard Personal**
   - Dashboard personal (`statistics-demo.component.ts`).
   - KPIs y gr�ficas.
   - **Presente:** S�.
   - **Reglas aplicadas:** Personalizaci�n, pruebas de componentes.

4. **Cat�logo de Libros**
   - Cat�logo (`products.component.ts`).
   - Filtros, paginaci�n, detalle de libro.
   - **Presente:** S�.
   - **Reglas aplicadas:** Reutilizaci�n, validaciones, pruebas unitarias.

5. **Compra de Libros**
   - Carrito y compra (`orders.component.ts`).
   - Formulario de compra, validaciones.
   - **Presente:** S�.
   - **Reglas aplicadas:** Pruebas de flujo, validaciones.

6. **Historial de Compras**
   - Historial (`orders.component.ts`).
   - Detalles, descarga de comprobantes.
   - **Presente:** S�.
   - **Reglas aplicadas:** Pruebas de exportaci�n, documentaci�n de historial.

7. **Gesti�n de Perfil**
   - Perfil (`settings.component.ts`).
   - Edici�n de datos, cambio de contrase�a, idioma.
   - **Presente:** S�.
   - **Reglas aplicadas:** Multilenguaje, accesibilidad, pruebas de formularios.

8. **Interfaz Responsiva y Multilenguaje**
   - Bootstrap y ngx-translate.
   - **Presente:** S�.
   - **Reglas aplicadas:** Accesibilidad, pruebas de responsividad.

---

### Mejoras en el Flujo del Cliente

1. **Creaci�n de cuenta (registro de cliente)**
   - El cliente puede registrarse desde la pantalla de login. Se a�ade una opci�n "Crear cuenta" que abre un formulario de registro con campos requeridos (nombre, correo electr�nico, contrase�a, confirmaci�n de contrase�a, tel�fono, direcci�n). El sistema valida los datos, muestra mensajes de �xito o error y redirige al login tras el registro exitoso.

2. **Notificaciones para el cliente**
   - El cliente visualiza notificaciones relevantes (compras, promociones, avisos) mediante el componente existente de notificaciones. Las notificaciones se muestran en el dashboard o men� principal y se gestionan con los servicios actuales.

3. **Favoritos o lista de deseos**
   - El cliente puede marcar libros como favoritos desde el cat�logo y consultar su lista de favoritos en el perfil o men�. La funcionalidad reutiliza componentes y servicios existentes para persistir la lista.

4. **Secci�n de ayuda o soporte**
   - Se incorpora una secci�n de ayuda accesible desde el men� principal, donde el cliente puede consultar preguntas frecuentes y datos de contacto. Se reutilizan estilos y estructura de componentes informativos.

5. **Promociones y recomendaciones**
   - Las promociones y productos recomendados se muestran en el dashboard o cat�logo, utilizando el banner existente para destacar ofertas y filtrando productos recomendados seg�n el historial de compras.

6. **Accesibilidad avanzada**
   - Se a�aden opciones de alto contraste y tama�o de fuente en la gesti�n de perfil, permitiendo al cliente personalizar la accesibilidad desde el perfil y persistiendo las preferencias con los servicios actuales.

---

## Cumplimiento y Recomendaciones

- Todas las funcionalidades del PRD que pueden ser cubiertas por el frontend actual est�n presentes en la soluci�n y alineadas con las reglas de codificaci�n y documentaci�n.
- Se recomienda:
  - Validar que los guards y permisos est�n correctamente configurados para cada rol.
  - Revisar que los formularios incluyan todas las validaciones requeridas.
  - Verificar que los endpoints y servicios cubran todos los campos y flujos del PRD.
  - Asegurar que la internacionalizaci�n y responsividad est�n implementadas en todos los componentes.
  - Documentar en cada componente la relaci�n con los requerimientos del PRD y las reglas del proyecto para facilitar el mantenimiento.

*No se incluyen reportes con Crystal Reports ni control de versiones, siguiendo las indicaciones.*

---

## Estructura Detallada del Frontend

### Componentes Principales (ubicaci�n: `src/app/components/`)
- **about/about.component.ts**: Pantalla "Acerca de".
- **controls/banner-demo.component.ts**: Banner demostrativo.
- **controls/notifications-viewer.component.ts**: Visualizaci�n de notificaciones.
- **controls/role-editor.component.ts**: Editor de roles.
- **controls/roles-management.component.ts**: Gesti�n de roles.
- **controls/search-box.component.ts**: Caja de b�squeda reutilizable.
- **controls/statistics-demo.component.ts**: Panel de KPIs y gr�ficas (dashboard).
- **customers/customers.component.ts**: Gesti�n y visualizaci�n de clientes.
- **home/home.component.ts**: Pantalla principal de bienvenida.
- **login/login.component.ts**: Pantalla de inicio de sesi�n.
- **not-found/not-found.component.ts**: P�gina de error 404.
- **orders/orders.component.ts**: Gesti�n y visualizaci�n de compras/pedidos.
- **products/products.component.ts**: Cat�logo y gesti�n de libros/productos.
- **settings/settings.component.ts**: Gesti�n de perfil, idioma y configuraci�n.

### Servicios Principales (ubicaci�n: `src/app/services/`)
- **account-endpoint.service.ts**: Comunicaci�n con API de cuentas.
- **account.service.ts**: L�gica de autenticaci�n y usuarios.
- **alert.service.ts**: Notificaciones y alertas.
- **app-title.service.ts**: Gesti�n del t�tulo de la app.
- **app-translation.service.ts**: Traducci�n y multilenguaje.
- **auth-guard.ts**: Protecci�n de rutas por autenticaci�n y roles.
- **auth.service.ts**: Manejo de tokens, login y roles.
- **configuration.service.ts**: Par�metros de configuraci�n.
- **endpoint-base.service.ts**: Base para servicios HTTP.
- **jwt-helper.ts**: Utilidades para JWT.
- **local-store-manager.service.ts**: Almacenamiento local.
- **notification-endpoint.service.ts**: Comunicaci�n con API de notificaciones.
- **notification.service.ts**: L�gica de notificaciones.
- **oidc-helper.service.ts**: Utilidades OIDC/OAuth2.
- **theme-manager.ts**: Gesti�n de temas visuales.
- **utilities.ts**: Utilidades generales.

### M�dulo Principal
- **app.module.ts**: M�dulo ra�z de la aplicaci�n Angular.
- **app.config.ts**: Configuraci�n global de providers, interceptores, animaciones, traducci�n, etc.

### Rutas y Navegaci�n (ubicaci�n: `src/app/app.routes.ts`)
- **Definici�n de rutas principales:**
  - `/` ? HomeComponent (protegida por AuthGuard)
  - `/login` ? LoginComponent
  - `/customers` ? CustomersComponent (protegida por AuthGuard)
  - `/products` ? ProductsComponent (protegida por AuthGuard)
  - `/orders` ? OrdersComponent (protegida por AuthGuard)
  - `/settings` ? SettingsComponent (protegida por AuthGuard)
  - `/about` ? AboutComponent
  - `/home` ? Redirecci�n a `/`
  - `**` ? NotFoundComponent
- **Protecci�n de rutas:**
  - Se usa `AuthGuard` para proteger rutas que requieren autenticaci�n y roles.
  - La visibilidad de opciones en el men� depende de los permisos del usuario (verificado en `app.component.ts`).

### Esquema de Navegaci�n
- Men� principal en `app.component.html` muestra opciones seg�n el rol y permisos.
- El router-outlet renderiza el componente correspondiente seg�n la ruta activa.
- Las rutas protegidas requieren autenticaci�n y permisos espec�ficos.

---

## Especificaci�n de APIs Backend

A continuaci�n se detallan los principales endpoints disponibles en la soluci�n, incluyendo rutas, m�todos, par�metros, ejemplos de request/response y reglas de autorizaci�n por endpoint.

### 1. Autenticaci�n y Autorizaci�n
- **POST /connect/token**
  - Solicita token JWT v�a OpenID Connect.
  - Par�metros: username, password (grant_type=password) o refresh_token (grant_type=refresh_token).
  - Ejemplo request:
    ```json
    { "grant_type": "password", "username": "admin", "password": "1234" }
    ```
  - Response: JWT y claims de usuario.
  - **Roles:** Todos (seg�n credenciales v�lidas).

### 2. Gesti�n de Productos (Libros)
- **GET /api/product**
  - Obtiene todos los productos.
  - Response: List<ProductVM>
  - **Roles:** Administrador, Vendedor, Cliente

- **GET /api/product/{id}**
  - Obtiene producto por ID.
  - Par�metro: id (int)
  - Response: ProductVM
  - **Roles:** Administrador, Vendedor, Cliente

- **POST /api/product**
  - Crea nuevo producto.
  - Body: ProductVM
  - Response: ProductVM creado
  - **Roles:** Administrador

- **PUT /api/product/{id}**
  - Actualiza producto existente.
  - Par�metro: id (int), Body: ProductVM
  - Response: ProductVM actualizado
  - **Roles:** Administrador

- **DELETE /api/product/{id}**
  - Elimina producto por ID.
  - Par�metro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 3. Gesti�n de Categor�as
- **GET /api/category**
  - Obtiene todas las categor�as.
  - Response: List<ProductCategory>
  - **Roles:** Administrador, Vendedor, Cliente

- **POST /api/category**
  - Crea nueva categor�a.
  - Body: ProductCategory
  - Response: ProductCategory creado
  - **Roles:** Administrador

- **PUT /api/category/{id}**
  - Actualiza categor�a existente.
  - Par�metro: id (int), Body: ProductCategory
  - Response: ProductCategory actualizado
  - **Roles:** Administrador

- **DELETE /api/category/{id}**
  - Elimina categor�a por ID.
  - Par�metro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 4. Gesti�n de Clientes
- **GET /api/customer**
  - Obtiene todos los clientes.
  - Response: List<CustomerVM>
  - **Roles:** (No protegido por roles, revisar para producci�n)

- **GET /api/customer/{id}**
  - Obtiene cliente por ID.
  - Par�metro: id (int)
  - Response: CustomerVM
  - **Roles:** (No protegido por roles, revisar para producci�n)

- **POST /api/customer**
  - Crea nuevo cliente.
  - Body: CustomerVM
  - Response: CustomerVM creado
  - **Roles:** (No protegido por roles, revisar para producci�n)

- **PUT /api/customer/{id}**
  - Actualiza cliente existente.
  - Par�metro: id (int), Body: CustomerVM
  - Response: CustomerVM actualizado
  - **Roles:** (No protegido por roles, revisar para producci�n)

- **DELETE /api/customer/{id}**
  - Elimina cliente por ID.
  - Par�metro: id (int)
  - Response: NoContent
  - **Roles:** (No protegido por roles, revisar para producci�n)

### 5. Gesti�n de Ventas (�rdenes)
- **GET /api/order**
  - Obtiene todas las ventas/�rdenes.
  - Response: List<OrderVM>
  - **Roles:** Administrador, Vendedor

- **POST /api/order**
  - Crea nueva venta/orden.
  - Body: OrderVM
  - Response: OrderVM creado
  - **Roles:** Administrador, Vendedor

- **PUT /api/order/{id}**
  - Actualiza venta/orden existente.
  - Par�metro: id (int), Body: OrderVM
  - Response: OrderVM actualizado
  - **Roles:** Administrador, Vendedor

- **DELETE /api/order/{id}**
  - Elimina venta/orden por ID.
  - Par�metro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 6. Gesti�n de Proveedores
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
  - Par�metro: id (int), Body: Proveedor
  - Response: Proveedor actualizado
  - **Roles:** Administrador

- **DELETE /api/proveedor/{id}**
  - Elimina proveedor por ID.
  - Par�metro: id (int)
  - Response: NoContent
  - **Roles:** Administrador

### 7. Gesti�n de Usuarios (Cuenta)
- **GET /api/account/users/me**
  - Obtiene datos del usuario actual.
  - Response: UserVM
  - **Roles:** Usuario autenticado

- **GET /api/account/users/{id}**
  - Obtiene usuario por ID.
  - Par�metro: id (string)
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
  - Par�metro: id (string), Body: UserEditVM
  - Response: NoContent
  - **Roles:** Usuario autenticado con permiso de actualizaci�n

- **DELETE /api/account/users/{id}**
  - Elimina usuario por ID.
  - Par�metro: id (string)
  - Response: UserVM eliminado
  - **Roles:** Usuario autenticado con permiso de eliminaci�n

---

## 8. Configuraciones y Entornos

### Archivos de Configuraci�n Principales

**Backend (.NET 9 / ASP.NET Core):**
- `appsettings.json` y `appsettings.Development.json`
  - Definen cadenas de conexi�n a la base de datos, configuraci�n SMTP para correo, par�metros de OIDC, logging y hosts permitidos.
  - Ejemplo de configuraci�n:
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
    - `DefaultConnection`: Cadena de conexi�n SQL Server.
    - `SmtpConfig`: Par�metros para env�o de correos (host, usuario, contrase�a, puerto, SSL).
    - `OIDC.Certificates`: Ruta y contrase�a de certificados para autenticaci�n OIDC.
    - `Logging`: Ruta y nivel de logs.
    - `AllowedHosts`: Hosts permitidos para la API.

**Frontend (Angular 19):**
- `src/environments/environment.ts` y `environment.prod.ts`
  - Configuran variables de entorno para desarrollo y producci�n.
  - Ejemplo:
    ```typescript
    export const environment: Environment = {
      production: false,
      baseUrl: "https://localhost:7085",
      fallbackBaseUrl: "https://quickapp.azurewebsites.net"
    };
    ```
  - **Variables relevantes:**
    - `production`: Indica si la app est� en modo producci�n.
    - `baseUrl`: URL base del servidor API (desarrollo: local, producci�n: host actual).
    - `fallbackBaseUrl`: URL alternativa si el API local no est� disponible.

- `src/app/app.config.ts`
  - Configura providers globales, rutas, animaciones, traducci�n, interceptores HTTP y manejo de errores.

- `src/app/services/configuration.service.ts`
  - Permite gestionar configuraciones de usuario (idioma, tema, URL de inicio, visibilidad de paneles) y persistirlas en localStorage.

### Endpoints de API

- **Backend principal:**
  - Desarrollo: `https://localhost:7085`
  - Producci�n: Host actual o configurado en `baseUrl`
  - Respaldo: `https://quickapp.azurewebsites.net` (recomendado actualizar a instancia propia)

- **Endpoints REST principales:**
  - Autenticaci�n: `/connect/token`
  - Productos: `/api/product`, `/api/product/{id}`
  - Categor�as: `/api/category`, `/api/category/{id}`
  - Clientes: `/api/customer`, `/api/customer/{id}`
  - �rdenes: `/api/order`, `/api/order/{id}`
  - Proveedores: `/api/proveedor`, `/api/proveedor/{id}`
  - Usuarios: `/api/account/users`, `/api/account/users/{id}`, `/api/account/users/me`

### Claves y Variables de Seguridad

- **SMTP:**
  - Usuario y contrase�a para env�o de correos definidos en `appsettings.json` (`SmtpConfig`).
- **Certificados OIDC:**
  - Ruta y contrase�a para certificados de autenticaci�n (`OIDC.Certificates`).
- **Tokens JWT/OIDC:**
  - Gestionados en frontend por `auth.service.ts` y en backend por OpenIddict y ASP.NET Core Identity.

### Configuraci�n de Logging

- **Ruta de logs:**
  - `Logs/log-{Date}.log` (configurable en `appsettings.json`)
- **Niveles de log:**
  - `Information` por defecto, `Warning` para ASP.NET Core.

### Configuraci�n de Internacionalizaci�n y Temas

- **Idioma:**
  - Configurable por usuario, persistido en localStorage (`configuration.service.ts`).
- **Tema visual:**
  - Seleccionable por usuario, persistido en localStorage.

### Resumen

La soluci�n utiliza archivos de configuraci�n separados para desarrollo y producci�n, variables de entorno en Angular, endpoints REST bien definidos y claves para correo y autenticaci�n. Las configuraciones de usuario (idioma, tema, paneles) se gestionan y persisten en el frontend. Los endpoints y claves sensibles deben ser protegidos y actualizados antes de despliegue en producci�n.

---

## Modelos de Datos

A continuaci�n se describe la estructura de los modelos principales utilizados en el backend (C#) y frontend (TypeScript), incluyendo sus propiedades, tipos, relaciones y validaciones relevantes.

### Backend (.NET 9 / C#)

#### Cliente
```csharp
public class Cliente : IAuditableEntity {
    public int Id { get; set; }
    public string Nombre { get; set; } // Requerido, m�x. 100
    public string? Email { get; set; } // M�x. 100
    public string? Telefono { get; set; } // M�x. 30
    public string? Direccion { get; set; } // M�x. 200
    public ICollection<Venta> Ventas { get; set; }
    // Auditor�a: CreatedBy, CreatedDate, UpdatedBy, UpdatedDate
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
    // Auditor�a
}
```

#### Categoria
```csharp
public class Categoria : IAuditableEntity {
    public int Id { get; set; }
    public string Nombre { get; set; } // Requerido
    public string? Descripcion { get; set; }
    public ICollection<Libro> Libros { get; set; }
    // Auditor�a
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
    // Auditor�a
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
- M�ximos: `Nombre` (100), `Email` (100), `Telefono` (30), `Direccion` (200), `Descripcion` (500), `Icon` (256).
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
- Validaciones de formularios: campos requeridos, formato de email, longitud m�xima/minima, coincidencia de contrase�as, etc.
- Validaciones adicionales implementadas con Angular Forms y validadores personalizados.

---

## Flujos de Negocio y Validaciones

### Reglas de Negocio Espec�ficas
- **L�gica de Stock:**
  - No se permite la venta de libros si el stock es insuficiente.
  - Al registrar una venta, se descuenta autom�ticamente el stock del libro vendido.
  - El sistema alerta cuando el stock de un libro es bajo (umbral configurable).
- **Restricciones de Edici�n y Eliminaci�n:**
  - Solo usuarios con rol Administrador pueden editar o eliminar productos, categor�as, clientes y proveedores.
  - Los clientes solo pueden editar su propio perfil y consultar su historial de compras.
  - Los vendedores pueden registrar ventas y consultar inventario, pero no modificar productos.
- **C�lculos de KPIs y Dashboard:**
  - KPIs principales: ventas del d�a, productos m�s vendidos, stock bajo, total de ingresos.
  - Los KPIs se calculan en tiempo real y se muestran en el dashboard mediante gr�ficas (ng2-charts, chart.js).
  - Los reportes permiten filtrar por fecha, cliente, categor�a y exportar a PDF.
- **Reportes:**
  - Reporte de ventas por periodo y de inventario bajo.
  - Acceso a reportes protegido por roles.

### Validaciones en Formularios y Backend
- **Backend (ASP.NET Core / FluentValidation):**
  - Validaci�n de campos obligatorios (`Nombre`, `Titulo`, `Autor`, etc.).
  - Validaci�n de formatos (email, tel�fono, fechas).
  - Restricci�n de valores m�nimos y m�ximos (stock, precio, longitud de texto).
  - Validaci�n de relaciones (no se puede eliminar una categor�a si tiene libros asociados).
  - Uso de `ModelState.IsValid` y validadores personalizados para cada entidad.
- **Frontend (Angular Forms):**
  - Formularios reactivos con validaciones en tiempo real.
  - Campos obligatorios, formato de email, longitud m�xima/m�nima, coincidencia de contrase�as.
  - Mensajes de error claros y accesibles en la interfaz.
  - Validaciones adicionales mediante directivas y validadores personalizados.

---

## Gesti�n de Errores y Mensajes

### Mensajes de Error y �xito Estandarizados
- **Backend:**
  - Respuestas de error: `BadRequest`, `NotFound`, `Unauthorized`, `ValidationProblem`, con mensajes claros y consistentes.
  - Respuestas de �xito: `Ok`, `CreatedAtAction`, `NoContent`, incluyendo detalles relevantes en el cuerpo JSON.
  - Ejemplo de error: `return BadRequest(ModelState);` o `return NotFound("Producto no encontrado");`
  - Ejemplo de �xito: `return Ok(productoVM);`
- **Frontend:**
  - Uso de `AlertService` para mostrar mensajes de �xito, error, advertencia y espera.
  - M�todos: `showMessage`, `showStickyMessage`, `showDialog` para notificaciones y di�logos.
  - Severidad estandarizada: `info`, `success`, `error`, `warn`, `wait`.
  - Mensajes accesibles y traducibles (multilenguaje).

### Flujos de Manejo de Errores
- **Backend:**
  - Validaci�n de datos con `ModelState.IsValid` y `FluentValidation`.
  - Manejo de excepciones con `try/catch` y clases personalizadas (`CustomerException`, etc.).
  - Registro de errores cr�ticos en logs (`ILogger`).
  - Env�o de mensajes de error estructurados al frontend.
- **Frontend:**
  - Captura de errores HTTP con interceptores y servicios base (`EndpointBase.handleError`).
  - Redirecci�n autom�tica en caso de expiraci�n de sesi�n o error cr�tico (`AuthService.reLogin`).
  - Notificaci�n al usuario mediante `AlertService` y mensajes contextuales.
  - Manejo global de errores con `AppErrorHandler` (recarga de p�gina ante error fatal).

---

## Pruebas y Criterios de Aceptaci�n

### Casos de Prueba Esperados por Funcionalidad
- **Autenticaci�n y Seguridad:**
  - Prueba de login con credenciales v�lidas e inv�lidas.
  - Prueba de recuperaci�n y cambio de contrase�a.
  - Prueba de acceso a rutas protegidas seg�n rol.
- **Gesti�n de Entidades (CRUD):**
  - Crear, consultar, modificar y eliminar libros, categor�as, ventas, clientes y proveedores.
  - Validaci�n de datos obligatorios y formatos.
  - Prueba de relaciones entre entidades (ej: no eliminar categor�a con libros asociados).
- **Dashboard y KPIs:**
  - Visualizaci�n de KPIs (ventas del d�a, stock bajo, productos m�s vendidos).
  - Actualizaci�n en tiempo real de gr�ficas y paneles.
- **Reportes:**
  - Generaci�n de reportes de ventas por periodo y de inventario bajo.
  - Prueba de filtros por fecha, cliente, categor�a y exportaci�n a PDF.
  - Prueba de acceso restringido a reportes por rol.
- **Gesti�n de Usuarios y Roles:**
  - Creaci�n y asignaci�n de roles.
  - Restricci�n de vistas y acciones seg�n rol.
- **Interfaz Web:**
  - Prueba de responsividad en diferentes dispositivos.
  - Validaci�n de formularios reactivos y mensajes de error.
  - Prueba de cambio de idioma y traducci�n de textos.
- **Consumo de APIs:**
  - Prueba de operaciones CRUD y reportes v�a servicios HTTP.
  - Prueba de manejo de tokens JWT y protecci�n de rutas.
- **Internacionalizaci�n y Accesibilidad:**
  - Prueba de cambio de idioma en tiempo real.
  - Prueba de accesibilidad en formularios y navegaci�n.

### Criterios para Considerar una Funcionalidad como �Terminada�
- Cumple con todos los requisitos funcionales y t�cnicos definidos en el PRD.
- Pasa todas las pruebas unitarias y de integraci�n (Jasmine/Karma para Angular, xUnit para .NET).
- La interfaz es responsiva y usable en diferentes dispositivos.
- La seguridad y protecci�n de datos est�n garantizadas.
- Los reportes son funcionales y exportables.
- La documentaci�n t�cnica y de usuario est� actualizada y disponible.
- El c�digo est� versionado y documentado seg�n las reglas del proyecto.
- No existen errores cr�ticos ni advertencias en el sistema.

---

## Gu�a de Estilos y UX

### Paleta de Colores
- El sistema utiliza temas Bootswatch (ej. Flatly, Minty, Superhero, Solar, Cerulean) basados en Bootstrap 5 y SASS.
- Colores principales: `$primary`, `$secondary`, `$success`, `$info`, `$warning`, `$danger`, `$light`, `$dark`.
- Cada tema define variantes y escalas de color para fondos, textos, botones y alertas.
- Ejemplo de paletas:
  - Flatly: Azul claro, gris, blanco, acentos en verde y naranja.
  - Minty: Verde menta, blanco, gris claro, acentos en azul.
  - Superhero: Azul oscuro, gris, blanco, acentos en rojo y amarillo.

### Tipograf�a
- Fuentes principales: Lato, Montserrat (importadas v�a Google Fonts en los temas).
- Tama�os y pesos adaptados para t�tulos, textos, men�s y botones.
- Uso de clases Bootstrap para encabezados, textos y botones.

### Iconograf�a
- Iconos FontAwesome y Material Icons integrados en componentes y formularios.
- Iconos para acciones principales: editar, eliminar, agregar, buscar, notificar, usuario, etc.
- Iconos accesibles y escalables.

### Layout
- Estructura SPA con Angular 19 y Bootstrap 5.
- Layout responsivo: men�s laterales/superiores, paneles, tarjetas, tablas y formularios adaptables.
- Uso de clases y utilidades Bootstrap para grid, espaciado, alineaci�n y visibilidad.
- Paneles de dashboard y KPIs con ng2-charts/chart.js.

### Reglas de Dise�o Responsivo y Accesibilidad
- Interfaz completamente responsiva, adaptada a m�viles, tablets y escritorio.
- Uso de utilidades Bootstrap y media queries para adaptar el layout.
- Formularios y componentes accesibles: etiquetas, roles ARIA, navegaci�n por teclado.
- Soporte multilenguaje con ngx-translate.
- Contraste adecuado y tama�os de fuente legibles.
- Mensajes y notificaciones accesibles y visibles.
- Pruebas de accesibilidad y responsividad incluidas en los criterios de aceptaci�n.

---

**Notas:**
- Todos los endpoints que requieren autenticaci�n y roles usan `[Authorize]` y/o `[Authorize(Roles = ...)]`.
- Los endpoints de clientes no est�n protegidos por roles en el c�digo actual, se recomienda agregar protecci�n antes de producci�n.
- Los endpoints devuelven respuestas en formato JSON.
- Para detalles adicionales y pruebas, consultar la documentaci�n Swagger en `/swagger`.
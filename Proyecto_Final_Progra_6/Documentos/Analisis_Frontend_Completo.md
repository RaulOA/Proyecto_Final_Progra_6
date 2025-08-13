# Análisis Completo del Frontend: Proyecto_Final_Progra_6.client

---

## 1. Funcionalidades Visuales y Acciones Disponibles

### Pantallas y Componentes Principales

- **Login / Autenticación**
  - Pantalla para iniciar sesión con usuario o correo.
  - Validación de credenciales.
  - Soporte para cuentas de admin y cliente.
  - Mensajes de error y recuperación de contraseña.

- **Catálogo de Libros**
  - Visualización de libros en formato de lista o tarjetas.
  - Filtros por categoría, autor, búsqueda por texto.
  - Detalle de cada libro (imagen, descripción, precio, autor, etc.).
  - Paginación y ordenamiento.

- **Compra de Libros**
  - Selección de libros y agregarlos al carrito.
  - Formulario de compra con validaciones.
  - Confirmación de compra y resumen de pedido.

- **Historial de Compras**
  - Listado de compras realizadas por el cliente.
  - Detalle de cada transacción (fecha, libros adquiridos, monto, estado).
  - Posibilidad de descargar comprobantes o ver detalles ampliados.

- **Dashboard Informativo**
  - Visualización de KPIs personales: total gastado, libros adquiridos, compras recientes.
  - Gráficas y estadísticas (ng2-charts, chart.js).
  - Paneles responsivos y adaptables.

- **Gestión de Perfil**
  - Visualización y edición de datos personales.
  - Cambio de contraseña.
  - Soporte para múltiples idiomas (ngx-translate).

- **Menú de Navegación**
  - Acceso a todas las secciones principales.
  - Menú lateral o superior, responsivo.
  - Opciones visibles según permisos/rol.

- **Interfaz Responsiva**
  - Adaptación a dispositivos móviles y escritorio.
  - Uso de Bootstrap y Bootswatch para estilos.

- **Soporte Multilenguaje**
  - Cambiar idioma de la interfaz en tiempo real.
  - Traducción de textos y mensajes.

- **Consumo de APIs**
  - Todas las acciones (login, compras, consultas) se realizan vía servicios HTTP.
  - Manejo de tokens JWT y protección de rutas.

---

## 2. Permisos y Roles

- **Admin**
  - Acceso total a todas las funcionalidades.
  - Puede ver y modificar clientes, libros, reportes, configuraciones.
  - Acceso a dashboards avanzados y reportes globales.

- **Cliente**
  - Acceso a catálogo, compra, historial, dashboard personal y perfil.
  - No puede modificar datos globales ni acceder a reportes administrativos.

- **Control de Acceso**
  - Las rutas y componentes están protegidos por guardas e interceptores.
  - El menú y las opciones visibles cambian según el rol.

---

## 3. Componentes y Partes Reutilizables

- **Componentes de Formulario**
  - Inputs, selects avanzados (ng-select), validaciones reutilizables.
  - Formularios de login, registro, compra, edición de perfil.

- **Componentes de Listado**
  - Listas y tablas para libros, compras, clientes.
  - Paginación, filtros y ordenamiento reutilizables.

- **Componentes de Gráficas**
  - Paneles de KPIs y estadísticas (ng2-charts, chart.js).

- **Componentes de Navegación**
  - Menús, barras laterales, breadcrumbs.

- **Componentes de Idioma**
  - Selector de idioma, traducción de textos.

- **Servicios Compartidos**
  - Servicios para consumo de APIs, manejo de autenticación, gestión de estado.

- **Estilos y Temas**
  - Temas Bootswatch, estilos globales y utilidades CSS.

---

## 4. ¿Quién Puede Hacer Qué?

- **Admin:** Todo lo anterior, más gestión de clientes, libros y reportes.
- **Cliente:** Catálogo, compra, historial, dashboard personal, edición de perfil, cambio de idioma.

---

## 5. Detalles Técnicos y Estructura

- **SPA Angular 19:** Navegación sin recarga, rutas protegidas.
- **Bootstrap 5:** Interfaz moderna y responsiva.
- **ng-select, ng2-charts:** Selects avanzados y gráficas.
- **ngx-translate:** Multilenguaje.
- **Jasmine/Karma:** Pruebas automatizadas de componentes.
- **ESLint:** Calidad y consistencia de código.
- **Reutilización:** Componentes y servicios modulares, fácil extensión.

---

**En resumen:**  
El cliente puede navegar, buscar, comprar, consultar historial, ver KPIs, editar perfil y cambiar idioma. El admin puede gestionar clientes, libros y reportes. Los componentes de formularios, listados, gráficas, navegación e idioma son reutilizables y modulares. Todo está protegido por roles y permisos, y la interfaz es responsiva y multilenguaje.

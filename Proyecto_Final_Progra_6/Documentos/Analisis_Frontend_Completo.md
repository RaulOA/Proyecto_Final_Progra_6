# An�lisis Completo del Frontend: Proyecto_Final_Progra_6.client

---

## 1. Funcionalidades Visuales y Acciones Disponibles

### Pantallas y Componentes Principales

- **Login / Autenticaci�n**
  - Pantalla para iniciar sesi�n con usuario o correo.
  - Validaci�n de credenciales.
  - Soporte para cuentas de admin y cliente.
  - Mensajes de error y recuperaci�n de contrase�a.

- **Cat�logo de Libros**
  - Visualizaci�n de libros en formato de lista o tarjetas.
  - Filtros por categor�a, autor, b�squeda por texto.
  - Detalle de cada libro (imagen, descripci�n, precio, autor, etc.).
  - Paginaci�n y ordenamiento.

- **Compra de Libros**
  - Selecci�n de libros y agregarlos al carrito.
  - Formulario de compra con validaciones.
  - Confirmaci�n de compra y resumen de pedido.

- **Historial de Compras**
  - Listado de compras realizadas por el cliente.
  - Detalle de cada transacci�n (fecha, libros adquiridos, monto, estado).
  - Posibilidad de descargar comprobantes o ver detalles ampliados.

- **Dashboard Informativo**
  - Visualizaci�n de KPIs personales: total gastado, libros adquiridos, compras recientes.
  - Gr�ficas y estad�sticas (ng2-charts, chart.js).
  - Paneles responsivos y adaptables.

- **Gesti�n de Perfil**
  - Visualizaci�n y edici�n de datos personales.
  - Cambio de contrase�a.
  - Soporte para m�ltiples idiomas (ngx-translate).

- **Men� de Navegaci�n**
  - Acceso a todas las secciones principales.
  - Men� lateral o superior, responsivo.
  - Opciones visibles seg�n permisos/rol.

- **Interfaz Responsiva**
  - Adaptaci�n a dispositivos m�viles y escritorio.
  - Uso de Bootstrap y Bootswatch para estilos.

- **Soporte Multilenguaje**
  - Cambiar idioma de la interfaz en tiempo real.
  - Traducci�n de textos y mensajes.

- **Consumo de APIs**
  - Todas las acciones (login, compras, consultas) se realizan v�a servicios HTTP.
  - Manejo de tokens JWT y protecci�n de rutas.

---

## 2. Permisos y Roles

- **Admin**
  - Acceso total a todas las funcionalidades.
  - Puede ver y modificar clientes, libros, reportes, configuraciones.
  - Acceso a dashboards avanzados y reportes globales.

- **Cliente**
  - Acceso a cat�logo, compra, historial, dashboard personal y perfil.
  - No puede modificar datos globales ni acceder a reportes administrativos.

- **Control de Acceso**
  - Las rutas y componentes est�n protegidos por guardas e interceptores.
  - El men� y las opciones visibles cambian seg�n el rol.

---

## 3. Componentes y Partes Reutilizables

- **Componentes de Formulario**
  - Inputs, selects avanzados (ng-select), validaciones reutilizables.
  - Formularios de login, registro, compra, edici�n de perfil.

- **Componentes de Listado**
  - Listas y tablas para libros, compras, clientes.
  - Paginaci�n, filtros y ordenamiento reutilizables.

- **Componentes de Gr�ficas**
  - Paneles de KPIs y estad�sticas (ng2-charts, chart.js).

- **Componentes de Navegaci�n**
  - Men�s, barras laterales, breadcrumbs.

- **Componentes de Idioma**
  - Selector de idioma, traducci�n de textos.

- **Servicios Compartidos**
  - Servicios para consumo de APIs, manejo de autenticaci�n, gesti�n de estado.

- **Estilos y Temas**
  - Temas Bootswatch, estilos globales y utilidades CSS.

---

## 4. �Qui�n Puede Hacer Qu�?

- **Admin:** Todo lo anterior, m�s gesti�n de clientes, libros y reportes.
- **Cliente:** Cat�logo, compra, historial, dashboard personal, edici�n de perfil, cambio de idioma.

---

## 5. Detalles T�cnicos y Estructura

- **SPA Angular 19:** Navegaci�n sin recarga, rutas protegidas.
- **Bootstrap 5:** Interfaz moderna y responsiva.
- **ng-select, ng2-charts:** Selects avanzados y gr�ficas.
- **ngx-translate:** Multilenguaje.
- **Jasmine/Karma:** Pruebas automatizadas de componentes.
- **ESLint:** Calidad y consistencia de c�digo.
- **Reutilizaci�n:** Componentes y servicios modulares, f�cil extensi�n.

---

**En resumen:**  
El cliente puede navegar, buscar, comprar, consultar historial, ver KPIs, editar perfil y cambiar idioma. El admin puede gestionar clientes, libros y reportes. Los componentes de formularios, listados, gr�ficas, navegaci�n e idioma son reutilizables y modulares. Todo est� protegido por roles y permisos, y la interfaz es responsiva y multilenguaje.

# Historia de Usuario Detallada – Sistema de Inventario y Ventas para Librería Universitaria

---

## Título
Como **Vendedor** de la Librería Universitaria, quiero registrar ventas y consultar el inventario de libros, para atender a los clientes de manera eficiente y mantener actualizada la información de productos y ventas.

---

## Descripción

El Vendedor necesita acceder a la plataforma web para realizar las siguientes tareas:

- Autenticarse de forma segura.
- Registrar nuevas ventas y asociar clientes.
- Consultar el inventario de libros y categorías disponibles.
- Visualizar KPIs y gráficos de ventas personales.
- Acceder a reportes de ventas por periodo (según permisos).
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptación

1. **Autenticación y Seguridad**
   - El Vendedor puede iniciar sesión con usuario y contraseña.
   - El sistema utiliza JWT para autenticación y autorización.
   - Puede recuperar y cambiar su contraseña desde la interfaz.

2. **Gestión de Ventas**
   - Puede crear, consultar y modificar ventas propias.
   - Puede asociar clientes a cada venta.
   - Las validaciones de datos se aplican automáticamente.

3. **Consulta de Inventario**
   - Puede consultar libros y categorías disponibles.
   - No puede modificar ni eliminar productos.

4. **Dashboard Informativo**
   - Visualiza KPIs y gráficos de ventas personales.
   - Los gráficos se actualizan en tiempo real.

5. **Reportes**
   - Puede generar reportes de ventas por periodo (según permisos).
   - Los reportes se pueden filtrar y exportar a PDF.

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - El sistema soporta múltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

---

## Escenario de Uso

1. El Vendedor accede a la URL de la plataforma y se autentica.
2. Navega al módulo de ventas y registra una nueva venta, asociando el cliente correspondiente.
3. Consulta el inventario de libros para verificar disponibilidad.
4. Visualiza el dashboard con sus ventas del día y productos más vendidos.
5. Genera un reporte de ventas del mes y lo descarga en PDF.
6. Cambia su contraseña y revisa la documentación técnica.
7. Realiza todas las operaciones desde su laptop y móvil, sin problemas de visualización.

---

## Notas Técnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptación y lineamientos definidos en el PRD.

---

# Historia de Usuario Detallada – Sistema de Inventario y Ventas para Librería Universitaria

---

## Título
Como **Cliente** de la Librería Universitaria, quiero consultar el catálogo de libros y mi historial de compras, para poder adquirir productos y revisar mis transacciones de manera sencilla y segura.

---

## Descripción

El Cliente necesita acceder a la plataforma web para realizar las siguientes tareas:

- Autenticarse de forma segura.
- Consultar el catálogo de libros y categorías disponibles.
- Realizar compras de libros.
- Consultar su historial de compras.
- Visualizar KPIs personales (por ejemplo, total gastado, libros adquiridos).
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptación

1. **Autenticación y Seguridad**
   - El Cliente puede iniciar sesión con usuario y contraseña.
   - El sistema utiliza JWT para autenticación y autorización.
   - Puede recuperar y cambiar su contraseña desde la interfaz.

2. **Consulta de Catálogo**
   - Puede consultar libros y categorías disponibles.
   - Puede buscar y filtrar productos por categoría, autor, etc.

3. **Compras**
   - Puede realizar compras de libros desde la plataforma.
   - Las validaciones de datos se aplican automáticamente.

4. **Historial de Compras**
   - Puede consultar su historial de compras y detalles de cada transacción.

5. **Dashboard Informativo**
   - Visualiza KPIs personales (total gastado, libros adquiridos).

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - El sistema soporta múltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

---

## Escenario de Uso

1. El Cliente accede a la URL de la plataforma y se autentica.
2. Consulta el catálogo de libros y filtra por categoría o autor.
3. Realiza la compra de uno o varios libros.
4. Consulta su historial de compras y revisa los detalles de cada transacción.
5. Visualiza el dashboard con KPIs personales.
6. Cambia su contraseña y revisa la documentación técnica.
7. Realiza todas las operaciones desde su laptop y móvil, sin problemas de visualización.

---

## Notas Técnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptación y lineamientos definidos en el PRD.

---

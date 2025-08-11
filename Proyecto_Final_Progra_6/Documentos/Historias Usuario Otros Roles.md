# Historia de Usuario Detallada � Sistema de Inventario y Ventas para Librer�a Universitaria

---

## T�tulo
Como **Vendedor** de la Librer�a Universitaria, quiero registrar ventas y consultar el inventario de libros, para atender a los clientes de manera eficiente y mantener actualizada la informaci�n de productos y ventas.

---

## Descripci�n

El Vendedor necesita acceder a la plataforma web para realizar las siguientes tareas:

- Autenticarse de forma segura.
- Registrar nuevas ventas y asociar clientes.
- Consultar el inventario de libros y categor�as disponibles.
- Visualizar KPIs y gr�ficos de ventas personales.
- Acceder a reportes de ventas por periodo (seg�n permisos).
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptaci�n

1. **Autenticaci�n y Seguridad**
   - El Vendedor puede iniciar sesi�n con usuario y contrase�a.
   - El sistema utiliza JWT para autenticaci�n y autorizaci�n.
   - Puede recuperar y cambiar su contrase�a desde la interfaz.

2. **Gesti�n de Ventas**
   - Puede crear, consultar y modificar ventas propias.
   - Puede asociar clientes a cada venta.
   - Las validaciones de datos se aplican autom�ticamente.

3. **Consulta de Inventario**
   - Puede consultar libros y categor�as disponibles.
   - No puede modificar ni eliminar productos.

4. **Dashboard Informativo**
   - Visualiza KPIs y gr�ficos de ventas personales.
   - Los gr�ficos se actualizan en tiempo real.

5. **Reportes**
   - Puede generar reportes de ventas por periodo (seg�n permisos).
   - Los reportes se pueden filtrar y exportar a PDF.

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - El sistema soporta m�ltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

---

## Escenario de Uso

1. El Vendedor accede a la URL de la plataforma y se autentica.
2. Navega al m�dulo de ventas y registra una nueva venta, asociando el cliente correspondiente.
3. Consulta el inventario de libros para verificar disponibilidad.
4. Visualiza el dashboard con sus ventas del d�a y productos m�s vendidos.
5. Genera un reporte de ventas del mes y lo descarga en PDF.
6. Cambia su contrase�a y revisa la documentaci�n t�cnica.
7. Realiza todas las operaciones desde su laptop y m�vil, sin problemas de visualizaci�n.

---

## Notas T�cnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptaci�n y lineamientos definidos en el PRD.

---

# Historia de Usuario Detallada � Sistema de Inventario y Ventas para Librer�a Universitaria

---

## T�tulo
Como **Cliente** de la Librer�a Universitaria, quiero consultar el cat�logo de libros y mi historial de compras, para poder adquirir productos y revisar mis transacciones de manera sencilla y segura.

---

## Descripci�n

El Cliente necesita acceder a la plataforma web para realizar las siguientes tareas:

- Autenticarse de forma segura.
- Consultar el cat�logo de libros y categor�as disponibles.
- Realizar compras de libros.
- Consultar su historial de compras.
- Visualizar KPIs personales (por ejemplo, total gastado, libros adquiridos).
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptaci�n

1. **Autenticaci�n y Seguridad**
   - El Cliente puede iniciar sesi�n con usuario y contrase�a.
   - El sistema utiliza JWT para autenticaci�n y autorizaci�n.
   - Puede recuperar y cambiar su contrase�a desde la interfaz.

2. **Consulta de Cat�logo**
   - Puede consultar libros y categor�as disponibles.
   - Puede buscar y filtrar productos por categor�a, autor, etc.

3. **Compras**
   - Puede realizar compras de libros desde la plataforma.
   - Las validaciones de datos se aplican autom�ticamente.

4. **Historial de Compras**
   - Puede consultar su historial de compras y detalles de cada transacci�n.

5. **Dashboard Informativo**
   - Visualiza KPIs personales (total gastado, libros adquiridos).

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - El sistema soporta m�ltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

---

## Escenario de Uso

1. El Cliente accede a la URL de la plataforma y se autentica.
2. Consulta el cat�logo de libros y filtra por categor�a o autor.
3. Realiza la compra de uno o varios libros.
4. Consulta su historial de compras y revisa los detalles de cada transacci�n.
5. Visualiza el dashboard con KPIs personales.
6. Cambia su contrase�a y revisa la documentaci�n t�cnica.
7. Realiza todas las operaciones desde su laptop y m�vil, sin problemas de visualizaci�n.

---

## Notas T�cnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptaci�n y lineamientos definidos en el PRD.

---

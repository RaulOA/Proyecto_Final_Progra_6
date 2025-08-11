# Historia de Usuario Detallada � Sistema de Inventario y Ventas para Librer�a Universitaria

---

## T�tulo
Como **Administrador** de la Librer�a Universitaria, quiero gestionar el inventario y las ventas de libros, para mantener el control de productos, ventas, clientes y reportes, asegurando la operaci�n eficiente y segura del negocio.

---

## Descripci�n

El Administrador necesita acceder a la plataforma web pa ra realizar las siguientes tareas:

- Autenticarse de forma segura.
- Registrar, editar y eliminar libros, categor�as, clientes, proveedores y ventas.
- Visualizar el estado del inventario y ventas mediante KPIs y gr�ficos.
- Generar y descargar reportes de ventas por periodo e inventario bajo en formato PDF.
- Asignar roles y permisos a otros usuarios (vendedores y clientes).
- Configurar par�metros generales del sistema.
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptaci�n

1. **Autenticaci�n y Seguridad**
   - El Administrador puede iniciar sesi�n con usuario y contrase�a.
   - El sistema utiliza JWT para autenticaci�n y autorizaci�n.
   - Puede recuperar y cambiar su contrase�a desde la interfaz.

2. **Gesti�n de Entidades**
   - Puede crear, consultar, modificar y eliminar libros, categor�as, ventas, clientes y proveedores.
   - Las validaciones de datos se aplican autom�ticamente (campos obligatorios, formatos, relaciones).
   - Las relaciones entre entidades (uno a muchos, muchos a muchos) se gestionan correctamente.

3. **Dashboard Informativo**
   - El Administrador visualiza KPIs relevantes (ventas del d�a, stock bajo, productos m�s vendidos).
   - Los gr�ficos se actualizan en tiempo real y son interactivos.

4. **Reportes**
   - Puede generar reportes de ventas por periodo y de inventario bajo.
   - Los reportes se pueden filtrar por fecha, cliente, categor�a y exportar a PDF.
   - El acceso a reportes est� protegido por roles.

5. **Gesti�n de Usuarios y Roles**
   - Puede crear y asignar roles (Administrador, Vendedor, Cliente).
   - Las vistas y acciones se restringen seg�n el rol asignado.

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - Los formularios son reactivos y validan los datos en tiempo real.
   - El sistema soporta m�ltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones CRUD y reportes se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

8. **Documentaci�n y Soporte**
   - El Administrador tiene acceso al manual t�cnico y puede consultar la documentaci�n desde la plataforma.

---

## Escenario de Uso

1. El Administrador accede a la URL de la plataforma y se autentica.
2. Navega al m�dulo de inventario y registra nuevos libros y categor�as.
3. Consulta el dashboard para revisar ventas y stock.
4. Registra una venta y asocia el cliente correspondiente.
5. Genera un reporte de ventas del mes y lo descarga en PDF.
6. Crea un nuevo usuario vendedor y le asigna el rol adecuado.
7. Cambia su contrase�a y revisa la documentaci�n t�cnica.
8. Realiza todas las operaciones desde su laptop y m�vil, sin problemas de visualizaci�n.

---

## Notas T�cnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptaci�n y lineamientos definidos en el PRD.

---
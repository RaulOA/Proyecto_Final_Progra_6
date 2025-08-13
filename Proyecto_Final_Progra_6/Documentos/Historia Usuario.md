# Historia de Usuario Detallada – Sistema de Inventario y Ventas para Librería Universitaria

---

## Título
Como **Administrador** de la Librería Universitaria, quiero gestionar el inventario y las ventas de libros, para mantener el control de productos, ventas, clientes y reportes, asegurando la operación eficiente y segura del negocio.

---

## Descripción

El Administrador necesita acceder a la plataforma web pa ra realizar las siguientes tareas:

- Autenticarse de forma segura.
- Registrar, editar y eliminar libros, categorías, clientes, proveedores y ventas.
- Visualizar el estado del inventario y ventas mediante KPIs y gráficos.
- Generar y descargar reportes de ventas por periodo e inventario bajo en formato PDF.
- Asignar roles y permisos a otros usuarios (vendedores y clientes).
- Configurar parámetros generales del sistema.
- Realizar todas las operaciones desde una interfaz responsiva y multilenguaje.

---

## Criterios de Aceptación

1. **Autenticación y Seguridad**
   - El Administrador puede iniciar sesión con usuario y contraseña.
   - El sistema utiliza JWT para autenticación y autorización.
   - Puede recuperar y cambiar su contraseña desde la interfaz.

2. **Gestión de Entidades**
   - Puede crear, consultar, modificar y eliminar libros, categorías, ventas, clientes y proveedores.
   - Las validaciones de datos se aplican automáticamente (campos obligatorios, formatos, relaciones).
   - Las relaciones entre entidades (uno a muchos, muchos a muchos) se gestionan correctamente.

3. **Dashboard Informativo**
   - El Administrador visualiza KPIs relevantes (ventas del día, stock bajo, productos más vendidos).
   - Los gráficos se actualizan en tiempo real y son interactivos.

4. **Reportes**
   - Puede generar reportes de ventas por periodo y de inventario bajo.
   - Los reportes se pueden filtrar por fecha, cliente, categoría y exportar a PDF.
   - El acceso a reportes está protegido por roles.

5. **Gestión de Usuarios y Roles**
   - Puede crear y asignar roles (Administrador, Vendedor, Cliente).
   - Las vistas y acciones se restringen según el rol asignado.

6. **Interfaz Web**
   - La plataforma es responsiva y se adapta a cualquier dispositivo.
   - Los formularios son reactivos y validan los datos en tiempo real.
   - El sistema soporta múltiples idiomas.

7. **Consumo de APIs**
   - Todas las operaciones CRUD y reportes se realizan mediante servicios HTTP seguros.
   - El sistema utiliza interceptores para manejar JWT y proteger las rutas.

8. **Documentación y Soporte**
   - El Administrador tiene acceso al manual técnico y puede consultar la documentación desde la plataforma.

---

## Escenario de Uso

1. El Administrador accede a la URL de la plataforma y se autentica.
2. Navega al módulo de inventario y registra nuevos libros y categorías.
3. Consulta el dashboard para revisar ventas y stock.
4. Registra una venta y asocia el cliente correspondiente.
5. Genera un reporte de ventas del mes y lo descarga en PDF.
6. Crea un nuevo usuario vendedor y le asigna el rol adecuado.
7. Cambia su contraseña y revisa la documentación técnica.
8. Realiza todas las operaciones desde su laptop y móvil, sin problemas de visualización.

---

## Notas Técnicas

- Todas las operaciones se realizan sobre una arquitectura .NET 9 + Angular 19.
- El sistema utiliza SQL Server y Crystal Reports para almacenamiento y reportes.
- El control de versiones se gestiona en GitHub.
- El sistema cumple con los criterios de aceptación y lineamientos definidos en el PRD.

---
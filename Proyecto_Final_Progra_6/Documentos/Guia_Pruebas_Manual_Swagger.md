# Gu�a de Pruebas Manuales en Swagger

Esta gu�a te ayudar� a validar manualmente los endpoints principales de la soluci�n usando la interfaz Swagger generada por Swashbuckle en el backend ASP.NET Core (.NET 9).

---

## 0. C�mo Iniciar el Backend Correctamente

1. Abre la soluci�n en Visual Studio o VS Code.
2. Selecciona el proyecto `Proyecto_Final_Progra_6.Server` como proyecto de inicio.
3. Verifica que la cadena de conexi�n en `appsettings.json` apunte a tu instancia de SQL Server.
4. Ejecuta el comando de migraci�n si es necesario:
   - En la terminal, navega a la carpeta del proyecto y ejecuta:
     ```powershell
     dotnet ef database update
     ```
5. Inicia el backend:
   - En Visual Studio: presiona F5 o haz clic en "Iniciar depuraci�n".
   - En terminal: ejecuta
     ```powershell
     dotnet run --project Proyecto_Final_Progra_6.Server/Proyecto_Final_Progra_6.Server.csproj
     ```
6. Espera a que la API est� corriendo y verifica la URL base (por defecto: `https://localhost:7085`).
7. Accede a `/swagger` para comenzar las pruebas manuales.

---

## 1. Acceso a Swagger
- Inicia el backend y accede a la URL `/swagger` en tu navegador (por defecto: `https://localhost:7085/swagger`).
- Verifica que todos los endpoints est�n documentados y accesibles.

---

## 2. Endpoints Principales a Probar

| Entidad/Funcionalidad | Endpoint | M�todos | Roles requeridos |
|-----------------------|----------|---------|------------------|
| Autenticaci�n         | /connect/token | POST | Todos (seg�n credenciales) |
| Usuarios              | /api/account/users, /api/account/users/{id}, /api/account/users/me | GET, POST, PUT, DELETE | Admin, Usuario autenticado |
| Roles                 | /api/account/roles, /api/account/roles/{id} | GET, POST, PUT, DELETE | Admin |
| Clientes              | /api/customer, /api/customer/{id} | GET, POST, PUT, DELETE | (Revisar protecci�n) |
| Productos             | /api/product, /api/product/{id} | GET, POST, PUT, DELETE | Admin, Vendedor, Cliente |
| Categor�as            | /api/category, /api/category/{id} | GET, POST, PUT, DELETE | Admin |
| �rdenes/Pedidos       | /api/order, /api/order/{id} | GET, POST, PUT, DELETE | Admin, Vendedor |
| Proveedores           | /api/proveedor, /api/proveedor/{id} | GET, POST, PUT, DELETE | Admin |

---

## 3. Pasos para Validar Cada Endpoint

1. **Autenticaci�n:**
   - Prueba el endpoint `/connect/token` con credenciales v�lidas e inv�lidas.
   - Verifica que se obtenga un JWT y los claims correctos.

2. **CRUD de Entidades:**
   - Para cada entidad (usuarios, clientes, productos, etc.), realiza las siguientes pruebas:
     - **GET**: Consulta todos y por ID. Verifica la respuesta y formato.
     - **POST**: Crea una nueva entidad. Valida los campos requeridos y la respuesta.
     - **PUT**: Actualiza una entidad existente. Prueba con datos v�lidos e inv�lidos.
     - **DELETE**: Elimina una entidad por ID. Verifica la respuesta y el estado.

3. **Roles y Permisos:**
   - Prueba endpoints protegidos con y sin autenticaci�n.
   - Verifica que los roles y permisos limiten correctamente el acceso.

4. **Validaciones y Errores:**
   - Prueba casos de error (campos faltantes, datos inv�lidos, acceso no autorizado).
   - Verifica que los mensajes de error sean claros y �tiles.

5. **Flujos Funcionales:**
   - Simula flujos completos (ejemplo: crear cliente, registrar orden, consultar historial).
   - Valida la integraci�n entre entidades (ejemplo: una orden debe tener cliente y productos v�lidos).

---

## 4. Registro de Resultados

- Documenta los resultados de cada prueba:
  - �El endpoint responde correctamente?
  - �Se respetan los roles y permisos?
  - �Los mensajes de error son claros?
  - �La integraci�n entre entidades funciona?
- Anota cualquier hallazgo, error o endpoint faltante.

---

## 5. Recomendaciones

- Realiza las pruebas con diferentes roles (Admin, Vendedor, Cliente) para validar la seguridad.
- Usa datos de prueba variados para cubrir casos l�mite.
- Si encuentras errores, documenta el request, la respuesta y el contexto.
- Repite las pruebas tras cada cambio relevante en el backend.

---

**Referencia:**
- Documentaci�n t�cnica y PRD en la carpeta `Documentos/`.
- Para dudas sobre modelos, revisa los archivos en `Core/Models/` y los ViewModels en el backend.

---

**Fin de la gu�a.**

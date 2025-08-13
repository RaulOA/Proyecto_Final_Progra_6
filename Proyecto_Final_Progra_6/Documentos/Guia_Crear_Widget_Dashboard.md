# Guía para Crear un Widget en el Dashboard (Angular)

Esta guía documenta los pasos reales y comprobados para crear, registrar y controlar un nuevo widget en el dashboard de la aplicación Angular, usando como referencia el widget de productos. Se irá completando con ejemplos y recomendaciones específicas para el proyecto.

---

## 1. Crear el componente del widget
- Ubica el nuevo componente en `src/app/components/controls/`.
- Ejemplo real: `products-demo.component.ts`, `products-demo.component.html`, `products-demo.component.scss`.
- El componente debe ser standalone y tener su lógica, template y estilos propios.

## 2. Registrar el widget en el dashboard
- Importa el componente en `home.component.ts`:
  ```typescript
  import { ProductsDemoComponent } from '../controls/products-demo.component';
  ```
- Agrega el componente al array `imports` del decorador `@Component` en `home.component.ts`.
- En `home.component.html`, inserta el selector del widget dentro del contenedor de widgets:
  ```html
  @if (configurations.showDashboardProducts) {
    <div id="dashboardProducts" ...>
      <app-products-demo></app-products-demo>
    </div>
  }
  ```
- Controla la visibilidad con la propiedad `showDashboardProducts` de la configuración.

## 3. Agregar el switch de preferencias
- En `user-preferences.component.html`, agrega un switch para mostrar/ocultar el widget:
  ```html
  <div class="row">
    <label ... for="dashboardProducts">{{'preferences.DashboardProducts' | translate}} </label>
    <div class="col-sm-4">
      <div class="form-check form-switch fs-5 pt-sm-1">
        <input name="dashboardProducts" [(ngModel)]="configurations.showDashboardProducts" class="form-check-input"
               type="checkbox" id="dashboardProducts">
      </div>
    </div>
    <div class="col-sm-5">
      <p ...>{{'preferences.DashboardProductsHint' | translate}}</p>
    </div>
  </div>
  ```
- El switch enlaza directamente con la propiedad de configuración.

## 4. Permisos (si aplica)
- El permiso para productos está definido en `src/app/models/permission.model.ts`:
  ```typescript
  export class Permissions {
    public static readonly viewProducts: PermissionValues = 'products.view';
  }
  ```
- El control de visibilidad por permisos debe implementarse en el componente de preferencias si se requiere.

## 5. Traducciones
- Las claves de traducción para el widget y el switch deben estar en los archivos de idioma, por ejemplo en `public/locale/es.json` y `public/locale/en.json`:
  ```json
  "preferences": {
    ...
    "DashboardProducts": "Productos del Panel:",
    "DashboardProductsHint": "Mostrar widget de productos/libros en el panel"
  }
  ```
- Ejemplo en inglés:
  ```json
  "preferences": {
    ...
    "DashboardProducts": "Dashboard Products:",
    "DashboardProductsHint": "Show products/books widget on the dashboard"
  }
  ```

## 6. Persistencia y configuración
- La propiedad `showDashboardProducts` debe estar definida y persistida en el servicio de configuración (`configuration.service.ts`).

## 7. Pruebas y validación
- Verifica que el widget se muestre/oculte correctamente desde las preferencias.
- Asegúrate de que la preferencia se guarda y restaura correctamente.

## 8. Etiquetas y traducciones internas del widget
- Si el widget tiene barra de búsqueda, columnas de tabla, mensajes de vacío, etc., define un espacio de nombres propio en los archivos de idioma (por ejemplo, `productsDemo`).
- Ejemplo en español (`es.json`):
  ```json
  "productsDemo": {
    "management": {
      "Search": "Buscar producto..."
    },
    "table": {
      "Name": "Nombre",
      "Description": "Descripción",
      "Price": "Precio",
      "Stock": "Stock",
      "NoProducts": "No se encontraron productos"
    }
  },
  ```
- Ejemplo en inglés (`en.json`):
  ```json
  "productsDemo": {
    "management": {
      "Search": "Search for product..."
    },
    "table": {
      "Name": "Name",
      "Description": "Description",
      "Price": "Price",
      "Stock": "Stock",
      "NoProducts": "No products found"
    }
  },
  ```
- Usa estas claves en las plantillas del widget para mantener consistencia y facilitar la traducción.

---

**Notas:**
- Esta guía refleja el estado real y comprobado en los archivos del proyecto.
- Mantén la coherencia visual y funcional con el resto de widgets.
- Documenta cualquier lógica especial o integración adicional.
- Si el widget requiere pasos adicionales (como endpoints, integración con otros servicios, etc.), agrégalos aquí conforme avances.

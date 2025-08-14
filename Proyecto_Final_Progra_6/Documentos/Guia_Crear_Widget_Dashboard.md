# Gu�a para Crear un Widget en el Dashboard (Angular)

Esta gu�a documenta los pasos estandarizados y buenas pr�cticas para crear, registrar y controlar un nuevo widget en el dashboard de la aplicaci�n Angular. El procedimiento es general y aplicable a cualquier widget, asegurando coherencia, internacionalizaci�n y mantenibilidad.

---

## 1. Crear el componente del widget
- Ubica el nuevo componente en `src/app/components/controls/`.
- Ejemplo: `mi-widget.component.ts`, `mi-widget.component.html`, `mi-widget.component.scss`.
- El componente debe ser standalone y tener su l�gica, template y estilos propios.
- **Recomendaci�n:** Usa el patr�n de imports y standalone de Angular 16+:
  ```typescript
  @Component({
    standalone: true,
    imports: [NgClass, FormsModule, TranslateModule, CommonModule, SearchBoxComponent, NgxDatatableModule],
    ...
  })
  ```

## 2. Registrar el widget en el dashboard
- Importa el componente en `home.component.ts`:
  ```typescript
  import { MiWidgetComponent } from '../controls/mi-widget.component';
  ```
- Agrega el componente al array `imports` del decorador `@Component` en `home.component.ts`.
- En `home.component.html`, inserta el selector del widget dentro del contenedor de widgets:
  ```html
  @if (configurations.showDashboardMiWidget) {
    <div id="dashboardMiWidget" ...>
      <app-mi-widget></app-mi-widget>
    </div>
  }
  ```
- Controla la visibilidad con una propiedad de configuraci�n (ej: `showDashboardMiWidget`).

## 3. Agregar el switch de preferencias
- En `user-preferences.component.html`, agrega un switch para mostrar/ocultar el widget:
  ```html
  <div class="row">
    <label ... for="dashboardMiWidget">{{'preferences.DashboardMiWidget' | translate}} </label>
    <div class="col-sm-4">
      <div class="form-check form-switch fs-5 pt-sm-1">
        <input name="dashboardMiWidget" [(ngModel)]="configurations.showDashboardMiWidget" class="form-check-input"
               type="checkbox" id="dashboardMiWidget">
      </div>
    </div>
    <div class="col-sm-5">
      <p ...>{{'preferences.DashboardMiWidgetHint' | translate}}</p>
    </div>
  </div>
  ```
- El switch enlaza directamente con la propiedad de configuraci�n.

## 4. Permisos (si aplica)
- Define el permiso en `src/app/models/permission.model.ts`:
  ```typescript
  export class Permissions {
    public static readonly viewMiWidget: PermissionValues = 'miwidget.view';
  }
  ```
- El control de visibilidad por permisos debe implementarse en el componente de preferencias si se requiere.

## 5. Traducciones
- Agrega las claves de traducci�n para el widget y el switch en los archivos de idioma (`public/locale/es.json`, `public/locale/en.json`, etc.):
  ```json
  "preferences": {
    ...
    "DashboardMiWidget": "Mi Widget en el Panel:",
    "DashboardMiWidgetHint": "Mostrar el widget personalizado en el panel"
  }
  ```
- Ejemplo en ingl�s:
  ```json
  "preferences": {
    ...
    "DashboardMiWidget": "Dashboard MyWidget:",
    "DashboardMiWidgetHint": "Show custom widget on the dashboard"
  }
  ```

## 6. Persistencia y configuraci�n
- La propiedad de visibilidad debe estar definida y persistida en el servicio de configuraci�n (`configuration.service.ts`).

## 7. Pruebas y validaci�n
- Verifica que el widget se muestre/oculte correctamente desde las preferencias.
- Aseg�rate de que la preferencia se guarda y restaura correctamente.

## 8. Etiquetas y traducciones internas del widget
- Si el widget tiene barra de b�squeda, columnas de tabla, mensajes de vac�o, botones, etc., define un espacio de nombres propio en los archivos de idioma (ejemplo: `miWidgetDemo`).
- Ejemplo en espa�ol (`es.json`):
  ```json
  "miWidgetDemo": {
    "management": {
      "Search": "Buscar elemento..."
    },
    "table": {
      "Name": "Nombre",
      "Description": "Descripci�n",
      "Price": "Precio",
      "Stock": "Stock",
      "AddToCart": "Agregar al carrito",
      "NoProducts": "No se encontraron elementos",
      "Loading": "Cargando elementos..."
    }
  },
  ```
- Ejemplo en ingl�s (`en.json`):
  ```json
  "miWidgetDemo": {
    "management": {
      "Search": "Search for item..."
    },
    "table": {
      "Name": "Name",
      "Description": "Description",
      "Price": "Price",
      "Stock": "Stock",
      "AddToCart": "Add to cart",
      "NoProducts": "No items found",
      "Loading": "Loading items..."
    }
  },
  ```
- Usa estas claves en las plantillas del widget para mantener consistencia y facilitar la traducci�n. Si agregas nuevas acciones o columnas, sigue este patr�n.

## 9. Tabla avanzada, b�squeda y ordenamiento (recomendado)
- Para widgets con tablas, utiliza `ngx-datatable` para soporte de ordenamiento, b�squeda y experiencia uniforme:
  - Declara un arreglo `columns` y una propiedad `rows` en el componente.
  - Usa solo `rows` como fuente de datos y filtra sobre ella en la b�squeda.
  - Ejemplo de patr�n:
    ```typescript
    columns: TableColumn[] = [
      { prop: 'name', name: $localize`:@@miWidgetDemo.table.Name:Nombre`, sortable: true },
      ...
    ];
    rows: MiEntidad[] = [];
    onSearchChanged(value: string) {
      const term = value?.toLowerCase() ?? '';
      this.rows = this.miListaOriginal.filter(x => x.name.toLowerCase().includes(term));
    }
    ```
  - En el template, usa:
    ```html
    <ngx-datatable [rows]="rows" [columns]="columns" ...></ngx-datatable>
    ```
- As� aseguras b�squeda y ordenamiento igual que en los widgets est�ndar del dashboard.

---

**Notas:**
- Esta gu�a es un procedimiento est�ndar y comprobado para cualquier widget.
- Mant�n la coherencia visual y funcional con el resto de widgets.
- Documenta cualquier l�gica especial o integraci�n adicional.
- Si el widget requiere pasos adicionales (como endpoints, integraci�n con otros servicios, etc.), agr�galos aqu� conforme avances.

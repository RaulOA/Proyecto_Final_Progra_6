/*
Autor: Raul Ortega Acuña
Archivo: home.component.ts
Solución: Proyecto_Final_Progra_6
Proyecto: Proyecto_Final_Progra_6.client
Ruta: Proyecto_Final_Progra_6/Proyecto_Final_Progra_6.client/src/app/components/home/home.component.ts

Descripción o propósito del archivo:
Componente de la página principal (dashboard) de la aplicación. Permite mostrar, ocultar y reorganizar widgets interactivos como estadísticas, notificaciones, tareas y banners, según las preferencias del usuario. Gestiona la persistencia del orden de los widgets y la interacción drag & drop. Cumple con los estándares de documentación y estructura definidos para Libreria Universidad.

Historial de cambios:
1. 27/04/2024 - Documentación y división en secciones según lineamientos de Libreria Universidad. Eliminación de referencias a plantillas y autores originales.

Alertas Críticas:
- 27/04/2024 - Se recomienda validar la persistencia del orden de widgets en diferentes navegadores y dispositivos. Revisar la accesibilidad del drag & drop para usuarios con movilidad reducida.
*/

// ======================================================== INICIO - IMPORTACIONES Y DECLARACIONES =========================================================
// Importación de módulos, servicios y componentes necesarios para el funcionamiento del dashboard y widgets.
import { AfterViewInit, Component, ElementRef, inject, viewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CdkDragDrop, moveItemInArray, CdkDropList, CdkDrag, CdkDragPlaceholder } from '@angular/cdk/drag-drop';
import { TranslateModule } from '@ngx-translate/core';
import { fadeInOut } from '../../services/animations';
import { ConfigurationService } from '../../services/configuration.service';
import { AuthService } from '../../services/auth.service';
import { StatisticsDemoComponent } from '../controls/statistics-demo.component';
import { NotificationsViewerComponent } from '../controls/notifications-viewer.component';
import { TodoDemoComponent } from '../controls/todo-demo.component';
import { BannerDemoComponent } from '../controls/banner-demo.component';
import { ProductsDemoComponent } from '../controls/products-demo.component';
// *********************************************************************************************************************************************
// Fin de importaciones y declaraciones globales.
// ======================================================== FIN - IMPORTACIONES Y DECLARACIONES =========================================================

// ======================================================== INICIO - INTERFACES Y TIPOS AUXILIARES =======================================================
// Definición de interfaces auxiliares para la gestión del orden de widgets.
// *********************************************************************************************************************************************
interface WidgetIndex { element: string, index: number }
// *********************************************************************************************************************************************
// Fin de interfaces y tipos auxiliares.
// ======================================================== FIN - INTERFACES Y TIPOS AUXILIARES =========================================================

// ======================================================== INICIO - DECORADOR Y CLASE PRINCIPAL ========================================================
// Definición del componente principal del dashboard y su lógica de interacción.
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  animations: [fadeInOut],
  imports: [
    CdkDropList, RouterLink, CdkDrag, CdkDragPlaceholder, StatisticsDemoComponent, NotificationsViewerComponent,
    TodoDemoComponent, BannerDemoComponent, ProductsDemoComponent, TranslateModule
  ]
})
export class HomeComponent implements AfterViewInit {
  // ======================================================== INICIO - PROPIEDADES Y DEPENDENCIAS =======================================================
  // Inyección de servicios y declaración de propiedades para el control del dashboard.
  private authService = inject(AuthService); // Servicio de autenticación
  configurations = inject(ConfigurationService); // Servicio de configuración global

  dragStartDelay = 200; // Retardo en milisegundos para iniciar el drag & drop
  readonly DBKeyWidgetsOrder = 'home-component.widgets_order'; // Clave para persistencia del orden de widgets

  // Referencia al contenedor de widgets en la vista
  readonly widgetsContainer = viewChild.required<ElementRef<HTMLDivElement>>('widgetsContainer');
  // *********************************************************************************************************************************************
  // Fin de propiedades y dependencias.
  // ======================================================== FIN - PROPIEDADES Y DEPENDENCIAS =========================================================

  // ======================================================== INICIO - MÉTODOS DE CICLO DE VIDA =========================================================
  // Métodos de ciclo de vida de Angular: inicialización de la vista.
  // *********************************************************************************************************************************************
  /**
   * Método que se ejecuta después de inicializar la vista. Restaura el orden de los widgets según la configuración guardada.
   */
  ngAfterViewInit(): void {
    this.restoreWidgetsOrder();
  }
  // *********************************************************************************************************************************************
  // Fin de métodos de ciclo de vida.
  // ======================================================== FIN - MÉTODOS DE CICLO DE VIDA ============================================================

  // ======================================================== INICIO - MÉTODOS DE ORDEN Y PERSISTENCIA DE WIDGETS =======================================
  // Métodos para restaurar, guardar y manipular el orden de los widgets en el dashboard.
  // *********************************************************************************************************************************************
  /**
   * Restaura el orden de los widgets desde la configuración persistida.
   */
  restoreWidgetsOrder() {
    const widgetIndexes = this.loadWidgetIndexes();
    if (widgetIndexes == null || widgetIndexes.length == 0)
      return;
    const parentEle = this.widgetsContainer().nativeElement;
    for (const widget of Array.from(parentEle.children)) {
      const index = widgetIndexes.find(w => w.element == widget.id)?.index;
      if (index != null)
        this.insertChildAtIndex(parentEle, widget, index);
    }
  }

  /**
   * Inserta un elemento hijo en una posición específica dentro del contenedor padre.
   * @param parent Contenedor padre
   * @param child Elemento a insertar
   * @param index Índice de destino
   */
  insertChildAtIndex(parent: HTMLDivElement, child: Element, index: number) {
    if (!index)
      index = 0;
    if (index >= parent.children.length) {
      parent.appendChild(child);
    } else {
      parent.insertBefore(child, parent.children[index]);
    }
  }

  /**
   * Guarda el orden actual de los widgets en la configuración persistente.
   * @param indexes Arreglo de índices de widgets
   */
  saveWidgetIndexes(indexes: WidgetIndex[]) {
    this.configurations
      .saveConfiguration(indexes, `${this.DBKeyWidgetsOrder}:${this.authService.currentUser?.id}`);
  }

  /**
   * Carga el orden de los widgets desde la configuración persistente.
   * @returns Arreglo de índices de widgets
   */
  loadWidgetIndexes() {
    return this.configurations
      .getConfiguration<WidgetIndex[]>(`${this.DBKeyWidgetsOrder}:${this.authService.currentUser?.id}`);
  }
  // *********************************************************************************************************************************************
  // Fin de métodos de orden y persistencia de widgets.
  // ======================================================== FIN - MÉTODOS DE ORDEN Y PERSISTENCIA DE WIDGETS ==========================================

  // ======================================================== INICIO - MÉTODOS DE INTERACCIÓN Y DRAG & DROP ============================================
  // Métodos para la interacción de usuario con widgets, incluyendo drag & drop y cálculo de alturas.
  // *********************************************************************************************************************************************
  /**
   * Calcula la altura mínima del placeholder durante el drag & drop.
   * @param placeholder Elemento placeholder
   * @param widget Widget correspondiente
   * @returns Altura mínima en píxeles
   */
  getPlaceholderMinHeight(placeholder: HTMLElement, widget: HTMLElement) {
    const placeholderMinHeight = parseInt(placeholder.style.minHeight, 10);
    return placeholderMinHeight || widget.offsetHeight;
  }

  /**
   * Maneja el evento de soltar un widget (drag & drop), actualizando el orden y persistiendo la nueva configuración.
   * @param event Evento de drag & drop
   */
  drop(event: CdkDragDrop<HTMLDivElement>) {
    const el = event.item.element.nativeElement;
    const parentEle = event.container.element.nativeElement;
    const anchorEle = parentEle.children[event.currentIndex];
    const widgetIndexes = new Array<WidgetIndex>(parentEle.children.length);
    for (let i = 0; i < parentEle.children.length; i++) {
      widgetIndexes[i] = { element: parentEle.children[i].id, index: i };
    }
    moveItemInArray(widgetIndexes, event.previousIndex, event.currentIndex);
    for (let i = 0; i < widgetIndexes.length; i++) {
      widgetIndexes[i].index = i;
    }
    if (event.currentIndex < event.previousIndex)
      parentEle.insertBefore(el, anchorEle);
    else
      parentEle.insertBefore(el, anchorEle.nextElementSibling);
    this.saveWidgetIndexes(widgetIndexes);
  }
  // *********************************************************************************************************************************************
  // Fin de métodos de interacción y drag & drop.
  // ======================================================== FIN - MÉTODOS DE INTERACCIÓN Y DRAG & DROP ===============================================
}
// *********************************************************************************************************************************************
// Fin de la declaración de la clase principal HomeComponent.
// ======================================================== FIN - DECORADOR Y CLASE PRINCIPAL ==========================================================

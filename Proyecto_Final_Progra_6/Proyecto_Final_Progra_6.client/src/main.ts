/// <reference types="@angular/localize" />

import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';

/**
 * Punto de entrada principal de la aplicación Angular.
 * Inicializa la aplicación usando el componente raíz {@link AppComponent}
 * y la configuración especificada en {@link appConfig}.
 *
 * Si ocurre un error durante el proceso de arranque, se muestra en la consola.
 */
bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));

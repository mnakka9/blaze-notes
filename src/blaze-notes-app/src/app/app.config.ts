import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { TodosEffects } from './store/todos/todos-effects';
import { todosReducer } from './store/todos/todos-reducer';
import { BlazeNotesApiService } from './api/services/blaze-notes-api.service';
import { ApiKeyInterceptor } from './api-key.interceptor';
import { provideAuth0 } from '@auth0/auth0-angular';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withFetch(), withInterceptors([ApiKeyInterceptor])),
    importProvidersFrom(
      StoreModule.forRoot({ }),
      EffectsModule.forRoot([]),
      StoreModule.forFeature('todos', todosReducer),
      EffectsModule.forFeature(TodosEffects),
      StoreDevtoolsModule.instrument({
        maxAge: 30,
        logOnly: false,
      })
    ),
    BlazeNotesApiService,
    provideAuth0({
      domain: 'domain',
      clientId: 'clientId',
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    })
  ],
};

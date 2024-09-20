import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TodosComponent } from './features/to-dos/todos/todos.component';
import { ProfileComponent } from './common/profile/profile.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'todo', component: TodosComponent },
  { path: 'todo/:id', component: TodosComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

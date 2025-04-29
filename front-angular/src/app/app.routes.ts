import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { 
    path: '', 
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule), 
    canActivate: [AuthGuard] 
  }, 
  { path: '**', redirectTo: 'login' } 
];




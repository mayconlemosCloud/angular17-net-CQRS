import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AuthState } from '../store/auth/auth.reducer';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router,private store: Store<{ auth: AuthState }>) {}

  canActivate(): Observable<boolean> {
    return this.store.select((state) => state.auth.isLogged).pipe(
      take(1), 
      map((isLogged) => {
        const token = localStorage.getItem('token');
        if (!isLogged && !token) {
          this.router.navigate(['/login']); 
          return false;
        }
        return true; 
      })
    );
  }
}

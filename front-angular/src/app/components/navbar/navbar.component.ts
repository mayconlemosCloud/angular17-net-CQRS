import { AsyncPipe, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AuthState } from '../../store/auth/auth.reducer';
import { clearAuthToken } from '../../store/auth/auth.actions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgIf,AsyncPipe],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  menuOpen = false;
  isLogged$: Observable<boolean>;
  
    constructor(private store: Store<{ auth?: AuthState }>, private router: Router) {
      this.isLogged$ = this.store.select((state) => state.auth?.isLogged ?? false);
    }
  
  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }

  logout() {
    this.store.dispatch(clearAuthToken());
    this.router.navigate(['/login']); // Navega para a página de login
  }
}

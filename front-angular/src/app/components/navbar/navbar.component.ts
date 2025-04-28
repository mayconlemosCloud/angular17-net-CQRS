import { AsyncPipe, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AuthState } from '../../store/auth/auth.reducer';

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
  
    constructor(private store: Store<{ auth?: AuthState }>) {
      this.isLogged$ = this.store.select((state) => state.auth?.isLogged ?? false);
    }
  
  toggleMenu() {
    this.menuOpen = !this.menuOpen;
  }
}

import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AuthState } from '../store/auth/auth.reducer';
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: true,
  imports: [RouterOutlet], 
})
export class HomeComponent implements OnInit {
  isLogged$: Observable<boolean>;

  constructor(private store: Store<{ auth: AuthState }>) {
    this.isLogged$ = this.store.select((state) => state.auth.isLogged);
  }

  ngOnInit() {}
}

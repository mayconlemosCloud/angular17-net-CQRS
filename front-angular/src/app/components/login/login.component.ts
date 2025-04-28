import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { setIsLogged } from '../../store/auth/auth.actions';
import { AuthService } from '../../../services/AuthService';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule], 
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private router: Router, private store: Store,
    private authService: AuthService,
    private toastr: ToastrService, 
  ) {}

  onSubmit() {
    if (this.email && this.password) {
      this.onLogin();
    } else {
      this.toastr.error('Preencha todos os campos!');
    }
  }

  onLogin() {
    this.authService.login({ email: this.email, password: this.password }).subscribe(
      (response) => {
        if (response.token) {
          localStorage.setItem('authToken', response.token);
          this.store.dispatch(setIsLogged({ isLogged: true })); 
          this.router.navigate(['/dashboard']);
        } else {
          this.toastr.success('Login Feito com sucesso!');
        }
      },
      (error) => {
        this.toastr.error('Falha no login!');
      }
    );   
  } 
}
  

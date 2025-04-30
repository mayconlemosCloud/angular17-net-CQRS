import { Component, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { setIsLogged } from '../../store/auth/auth.actions';
import { AuthService } from '../../../services/AuthService';
import { ToastrService } from 'ngx-toastr';
import { NgIf } from '@angular/common';

type AccountData = {
  email: string;
  password: string;
  username: string;
  phone: string;
  status: number; 
  role: number;
};


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [FormsModule,NgIf], 
})
export class LoginComponent {
  form = {
    email: '',
    password: '',
    confirmPassword: '',
    username: '',
    phone: '',
    status: false, // Default value for the checkbox
    role: 0, // Default role value
  };
  showCreateAccountModal = false;
  isLoading: boolean = false;

  constructor(private router: Router, private store: Store,
    private authService: AuthService,
    private toastr: ToastrService,
  ) {
    const token = localStorage.getItem('token');
    if (token) {
      this.store.dispatch(setIsLogged({ isLogged: true }));
      this.router.navigate(['/dashboard']);
    }
  }

  onSubmit() {
    if (this.showCreateAccountModal) {
      this.handleCreateAccount();
      return;
    }

    this.handleLogin();
  }

  private handleCreateAccount() {
    const { email, password, confirmPassword, username, phone, status, role } = this.form;

    if (!email || !password || !confirmPassword) {
      this.toastr.error('Preencha todos os campos!');
      return;
    }

    if (password !== confirmPassword) {
      this.toastr.error('As senhas não correspondem. Por favor, tente novamente.');
      return;
    }

    const accountData: AccountData = {
      email,
      password,
      username,
      phone,
      status: status ? 1 : 0,
      role: Number(role), 
    };

    this.authService.createAccount(accountData).subscribe(
      (response) => {
        this.form = { email: '', password: '', confirmPassword: '', username: '', phone: '', status: false, role: 0 };
        this.showCreateAccountModal = false;
        this.toastr.success('Conta criada com sucesso!');
      },
      (error) => {
        this.toastr.error('Falha ao criar conta!');
      }
    );
  }

  private handleLogin() {
    const { email, password } = this.form;

    if (!email || !password) {
      this.toastr.error('Preencha todos os campos!');
      return;
    }

    this.authService.login({ email, password }).subscribe(
      (response) => {
        if (response.data.data.token) {
          localStorage.setItem('token', response.data.data.token);
          this.store.dispatch(setIsLogged({ isLogged: true }));
          this.router.navigate(['/dashboard']);
          this.toastr.success('Login Feito com sucesso!');
        }
      },
      () => {
        this.toastr.error('Falha no login!');
      }
    );
  }

  toggleCreateAccount() {
    this.showCreateAccountModal = !this.showCreateAccountModal;
  }
}


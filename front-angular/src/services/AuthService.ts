import { Injectable } from '@angular/core';
import { AuthRepository } from '../repositories/AuthRepository';
import { Observable } from 'rxjs';

type AuthRepositoryInterface = {
    email: string;
    password: string;
  }
  

@Injectable({
  providedIn: 'root',
})
export class AuthService  {
  constructor(private repository: AuthRepository) {}
  
  login(data: AuthRepositoryInterface): Observable<any> {
    return this.repository.login(data);
  }

  createAccount(data: any): Observable<any> {
    return this.repository.createAccount(data);
  }
}

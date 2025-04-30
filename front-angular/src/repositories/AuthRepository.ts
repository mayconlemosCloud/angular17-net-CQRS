import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';



@Injectable({
  providedIn: 'root',
})
export class AuthRepository {
  private rota = `${environment.apiUrl}/auth`;
  private rotaUser = `${environment.apiUrl}/users`;
  constructor(private http: HttpClient) {}

  login(data: any): Observable<any> {
    return this.http.post<any>(`${this.rota}`, data);
  }

  createAccount(data: any): Observable<any> {
    return this.http.post<any>(`${this.rotaUser}`, data);
  }

}

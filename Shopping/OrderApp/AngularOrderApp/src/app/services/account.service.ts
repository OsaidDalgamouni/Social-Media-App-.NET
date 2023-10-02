import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../Models/login';
import { RegisterUser } from '../Models/register-user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  url: string = " https://localhost:7116/api/account";
  

  constructor(private Httpclient: HttpClient) { }
  public PostRegister(Registeruser: RegisterUser): Observable<RegisterUser> {
    return this.Httpclient.post<RegisterUser>(`${this.url}`, Registeruser);
  }
  public PostLogin(login: Login): Observable<any> {
    return this.Httpclient.post<any>(`${this.url}/login`, login);
  }
}

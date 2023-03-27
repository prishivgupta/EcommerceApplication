import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Login } from 'src/app/Models/Login';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/Models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private routes: Router) { }

  baseUrl: string = "https://localhost:7018/api/Auth/";

  login(data: Login): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'LoginUser', data)
  }

  register(data: User): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'RegisterUser', data)
  }

  storeToken(token: string) {
    localStorage.setItem('token', token)
  }

  getToken() {
    return localStorage.getItem('token')
  }

  isLoggedIn(): boolean {
    return !! localStorage.getItem('token')
  }

  logout() {
    localStorage.clear();
    this.routes.navigate(['login'])
  }
}


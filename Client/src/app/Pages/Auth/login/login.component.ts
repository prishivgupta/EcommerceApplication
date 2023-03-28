import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/Models/Login';
import { Location } from '@angular/common';
import { AuthService } from 'src/app/Services/Auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private authService: AuthService, private location: Location, private routes: Router) {}

  login: Login = {
    userEmail: '',
    userPassword: ''
  };

  loginUser(login : Login): void {
    this.authService.login(login).subscribe(data => {
      this.authService.storeToken(data.result)
      this.routes.navigate([''])
    })
  }
}

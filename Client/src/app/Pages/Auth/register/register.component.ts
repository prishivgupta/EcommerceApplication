import { Component } from '@angular/core';
import { AuthService } from 'src/app/Services/Auth/auth.service';
import { Router } from '@angular/router';
import { Login } from 'src/app/Models/Login';
import { Location } from '@angular/common';
import { User } from 'src/app/Models/User';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(private authService: AuthService, private location: Location, private routes: Router) {}

  register: User = {
    userId: 0,
    userName: '',
    userEmail: '',
    userPassword: '',
    userPhoneNumber: '',
    userRole: 'User',
    userAddress: '',
    cartId: 0
  };

  registerUser(register : User): void {
    this.authService.register(register).subscribe(data => {
      console.log(data)
      this.authService.storeToken(data.token)
      this.routes.navigate([''])
    })
  }
}
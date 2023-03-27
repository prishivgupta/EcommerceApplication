import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../Services/Auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private routes: Router, private authService: AuthService) {}

  canActivate(): boolean {

    if (this.authService.isLoggedIn()) {
      return true;
    } else {
      this.routes.navigate(['login'])
      return false;
    }
    
  }
}

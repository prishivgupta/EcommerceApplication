import { Component } from '@angular/core';
import { AuthService } from 'src/app/Services/Auth/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  constructor(private authService: AuthService) {}

  logout(): void {
    this.authService.logout();
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  isVisible(): boolean {
    if(localStorage.getItem('userRole') == "Admin" && localStorage.getItem('token')) {
      return true;
    } else {
      return false
    }
  }

  ngOnInit(): void {
    this.isVisible();
  }
}

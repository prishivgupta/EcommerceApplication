import { Component } from '@angular/core';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/Users/user.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {

  constructor(private userService: UserService, private location: Location) {}

  user: User = {
    userId: 0,
    userName: '',
    userEmail: '',
    userPassword: '',
    userPhoneNumber: '',
    userRole: '',
    userAddress: '',
    cartId: 0
  };

  goBack(): void {
    this.location.back();
  }

  addUser(user: User): void {
    this.userService.addUser(user).subscribe(() => this.goBack());
  }

}

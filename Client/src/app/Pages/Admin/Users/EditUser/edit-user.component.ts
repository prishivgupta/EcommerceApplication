import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/Users/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {

  constructor(private userService: UserService, private location: Location, private route: ActivatedRoute) {}

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

  editUser(user: User): void {
    this.userService.updateUser(user).subscribe(() => this.goBack());
  }

  getUserById(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.userService.getUserById(id).subscribe(user => {
      this.user.userId = user.userId,
      this.user.userEmail = user.userEmail,
      this.user.userName = user.userName,
      this.user.userName = user.userName,
      this.user.userPhoneNumber = user.userPhoneNumber,
      this.user.userAddress = user.userAddress,
      this.user.userRole = user.userRole,
      this.user.cartId = user.cartId
    });
  }

  ngOnInit(): void {
    this.getUserById()
  }

}

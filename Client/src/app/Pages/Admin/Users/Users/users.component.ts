import { Component } from '@angular/core';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/Services/Users/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent {

  constructor(private userService: UserService) {}

  users: User[] = [];
  id?: number;
  

  getAllUsers(): void {
    this.userService.getAllUsers().subscribe(users => this.users = users);
  }

  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe(() => this.getAllUsers());
  }

  ngOnInit(): void {
    this.getAllUsers();
  }

}

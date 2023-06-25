import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/models/userModel';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit{
  userList: UserModel[] = [];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe({
      next: (data: UserModel[]) => {
        this.userList = data;
        console.log(this.userList);
      },
      error: (data: any) => {
        alert("Error leyendo la información");
        console.log(this.userList);
      }
    });
  }
}

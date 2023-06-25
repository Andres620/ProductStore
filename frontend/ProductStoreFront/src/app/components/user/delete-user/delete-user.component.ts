import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModel';
import { UserService } from 'src/app/services/user.service';
import 'src/assets/js/mdb.min.js';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css'],
})
export class DeleteUserComponent implements OnInit {
  recordId: number = 0;
  recordName: string = '';
  recordEmail: string = '';

  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.recordId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.searchRecord();
  }

  searchRecord() {
    this.userService.getUsersById(this.recordId).subscribe({
      next: (data: UserModel) => {
        this.recordId = data.id ?? 0;
        this.recordName = data.nombre ?? '';
        this.recordEmail = data.correoElectronico ?? '';
      },
      error: (err: any) => {
        alert('Error: El registro no existe');
        console.log('record: ', this.recordId);
      },
    });
  }

  deleteRecord() {
    this.userService.deleteUser(this.recordId).subscribe({
      next: (data: any) => {
        alert('Usuario eliminada correctamente');
        this.router.navigate(['list-users']);
      },
      error: (err: any) => {
        alert('Ha ocurrido un error');
      },
    });
  }

}

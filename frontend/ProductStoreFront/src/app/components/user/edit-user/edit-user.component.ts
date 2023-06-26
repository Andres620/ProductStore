import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModel';
import { UserService } from 'src/app/services/user.service';
import 'src/assets/js/mdb.min.js'; 

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit{
  fGroup: FormGroup = new FormGroup({});
  recordId: number = 0;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.recordId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    this.buildFormData();
    this.searchRecord();
  }

  searchRecord(){
    this.userService.getUsersById(this.recordId).subscribe({
      next: (data: UserModel) => {
        this.getFgData['id'].setValue(data.id);
        this.getFgData['nombre'].setValue(data.nombre);
        this.getFgData['correoElectronico'].setValue(data.correoElectronico);
        this.getFgData['contrasena'].setValue(data.contrasena);
      },
      error: (err: any) => {
        alert("Error: El registro no existe");
        console.log("record: ", this.recordId);
      }
    })
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      id: ['', [Validators.required]],
      nombre: ['', [Validators.required]],
      correoElectronico: ['', [Validators.required]],
      contrasena: ['', [Validators.required]],
    });
  }

  editRecord(){
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.userService.editUser(model).subscribe({
        next: (data: UserModel) => {
          alert('Usuario actualizado correctamente');
          this.router.navigate(['list-users']);
        },
        error: (err: any) => {
          alert("Ha ocurrido un error");
        }
      });
    }
  }

  getRecord(): UserModel {
    let model = new UserModel();
    model.id = this.getFgData['id'].value;
    model.nombre = this.getFgData['nombre'].value;
    model.correoElectronico = this.getFgData['correoElectronico'].value;
    model.contrasena = this.getFgData['contrasena'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

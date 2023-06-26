import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModel';

import { UserService } from 'src/app/services/user.service';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  fGroup: FormGroup = new FormGroup({});
  isLoggedin: boolean = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router,
    private globalService: GlobalService
  ) {}

  ngOnInit(): void {
    this.buildFormData();
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      correoElectronico: ['', [Validators.required, Validators.email]],
      contrasena: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
        ],
      ],
    });
  }

  autenticateRecord() {
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.userService.autenticateUser(model.correoElectronico ?? '', model.contrasena ?? '').subscribe({
        next: (data: UserModel) => {
          alert('Se ha iniciado sesión correctamente correctamente');
          this.globalService.globalVariable.next(true);
          this.globalService.globalVariable.subscribe(value => {
            this.isLoggedin = value;
          });
          this.router.navigate(['/list-products']);
        },
        error: (err: any) => {
          alert(
            'Error: Correo o contraseña incorrectos, por favor verifique sus datos'
          );
          this.globalService.globalVariable.next(false);
          this.globalService.globalVariable.subscribe(value => {
            this.isLoggedin = value;
          });
        },
      });
    }
  }

  getRecord(): UserModel {
    let model = new UserModel();
    model.correoElectronico = this.getFgData['correoElectronico'].value;
    model.contrasena = this.getFgData['contrasena'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

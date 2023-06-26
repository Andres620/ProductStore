import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/userModel';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  fGroup: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.buildFormData();
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      nombre: ['', [Validators.required, Validators.minLength(3)]],
      correoElectronico: ['', [Validators.required, Validators.email]],
      contrasena: ['', [Validators.required,
          Validators.minLength(8), 
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[_\\-.@$!%*?&])[A-Za-z\\d_\\-.@$!%*?&]+$')]],
    });
  }

  saveRecord() {
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.userService.saveUser(model).subscribe({
        next: (data: UserModel) => {
          alert('Usuario registrado correctamente');
          this.router.navigate(['/list-products']);
        },
        error: (err: any) => {
          alert("Error: Esta dirección de correo electrónico ya está registrada");
        }
      });
    }
  }

  getRecord(): UserModel {
    let model = new UserModel();
    model.nombre = this.getFgData['nombre'].value;
    model.correoElectronico = this.getFgData['correoElectronico'].value;
    model.contrasena = this.getFgData['contrasena'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductModel } from 'src/app/models/productModel';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit{
  fGroup: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.buildFormData();
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      nombre: ['', [Validators.required]],
      descripcion: ['', [Validators.required]],
      precio: ['', [Validators.required]],
    });
  }

  saveRecord() {
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.productService.saveProduct(model).subscribe({
        next: (data: ProductModel) => {
          alert('Producto registrado correctamente');
          this.router.navigate(['/list-products']);
        },
        error: (err: any) => {
          alert("Error: Esta dirección de correo electrónico ya está registrada");
        }
      });
    }
  }

  getRecord(): ProductModel {
    let model = new ProductModel();
    model.nombre = this.getFgData['nombre'].value;
    model.descripcion = this.getFgData['descripcion'].value;
    model.precio = this.getFgData['precio'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

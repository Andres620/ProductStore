import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductModel } from 'src/app/models/productModel';
import { ProductService } from 'src/app/services/product.service';

import 'src/assets/js/mdb.min.js'; 

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})

export class EditProductComponent implements OnInit{
  fGroup: FormGroup = new FormGroup({});
  recordId: number = 0;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
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
    this.productService.getProductsById(this.recordId).subscribe({
      next: (data: ProductModel) => {
        this.getFgData['id'].setValue(data.id);
        this.getFgData['nombre'].setValue(data.nombre);
        this.getFgData['descripcion'].setValue(data.descripcion);
        this.getFgData['precio'].setValue(data.precio);
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
      descripcion: ['', [Validators.required]],
      precio: ['', [Validators.required]],
    });
  }

  editRecord(){
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.productService.editProduct(model).subscribe({
        next: (data: ProductModel) => {
          alert('Producto actualizado correctamente');
          this.router.navigate(['list-orders']);
        },
        error: (err: any) => {
          alert("Ha ocurrido un error");
        }
      });
    }
  }

  getRecord(): ProductModel {
    let model = new ProductModel();
    model.id = this.getFgData['id'].value;
    model.nombre = this.getFgData['nombre'].value;
    model.descripcion = this.getFgData['descripcion'].value;
    model.precio = this.getFgData['precio'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

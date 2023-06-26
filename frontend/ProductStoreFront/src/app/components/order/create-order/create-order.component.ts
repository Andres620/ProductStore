import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OrderModel } from 'src/app/models/orderModel';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit{
  fGroup: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.buildFormData();
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      usuarioId: ['', [Validators.required]],
      productoId: ['', [Validators.required]],
      fecha: ['', [Validators.required]],
      cantidad: ['', [Validators.required]]
    });
  }

  saveRecord() {
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.orderService.saveOrder(model).subscribe({
        next: (data: OrderModel) => {
          alert('Usuario registrado correctamente');
          this.router.navigate(['/list-orders']);
        },
        error: (err: any) => {
          alert("Error: Esta dirección de correo electrónico ya está registrada");
        }
      });
    }
  }

  getRecord(): OrderModel {
    let model = new OrderModel();
    model.usuarioId = this.getFgData['usuarioId'].value;
    model.productoId = this.getFgData['productoId'].value;
    model.fecha = this.getFgData['fecha'].value;
    model.cantidad = this.getFgData['cantidad'].value;
    return model;
  }

  get getFgData() {
    return this.fGroup.controls;
  }
}

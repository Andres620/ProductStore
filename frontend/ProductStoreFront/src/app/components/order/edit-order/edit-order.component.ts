import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderModel } from 'src/app/models/orderModel';
import { OrderService } from 'src/app/services/order.service';


@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css'],
})
export class EditOrderComponent implements OnInit{
  fGroup: FormGroup = new FormGroup({});
  recordId: number = 0;

  constructor(
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.recordId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.buildFormData();
    this.searchRecord();
  }

  searchRecord() {
    this.orderService.getOrdersById(this.recordId).subscribe({
      next: (data: OrderModel) => {
        this.getFgData['id'].setValue(data.id);
        this.getFgData['usuarioId'].setValue(data.usuarioId);
        this.getFgData['productoId'].setValue(data.productoId);
        this.getFgData['fecha'].setValue(data.fecha);
        this.getFgData['cantidad'].setValue(data.cantidad);
      },
      error: (err: any) => {
        alert('Error: El registro no existe');
        console.log('record: ', this.recordId);
      },
    });
  }

  buildFormData() {
    this.fGroup = this.fb.group({
      id: ['', [Validators.required]],
      usuarioId: ['', [Validators.required]],
      productoId: ['', [Validators.required]],
      fecha: ['', [Validators.required]],
      cantidad: ['', [Validators.required]],
    });
  }

  editRecord() {
    if (this.fGroup.invalid) {
      alert('Formulario invalido: Debe diligenciar todo el formulario');
    } else {
      let model = this.getRecord();
      this.orderService.editOrder(model).subscribe({
        next: (data: OrderModel) => {
          alert('Pedido actualizado correctamente');
          this.router.navigate(['list-orders']);
        },
        error: (err: any) => {
          alert('Ha ocurrido un error');
        },
      });
    }
  }

  getRecord(): OrderModel {
    let model = new OrderModel();
    model.id = this.getFgData['id'].value;
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

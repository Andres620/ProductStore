import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderModel } from 'src/app/models/orderModel';
import { OrderService } from 'src/app/services/order.service';

import 'src/assets/js/mdb.min.js';

@Component({
  selector: 'app-delete-order',
  templateUrl: './delete-order.component.html',
  styleUrls: ['./delete-order.component.css']
})
export class DeleteOrderComponent implements OnInit {
  recordId: number = 0;
  recordUserId: number = 0;
  recordProductId: number = 0;
  recordDate: Date = new Date();
  recordQuantity: number = 0;

  constructor(
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.recordId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.searchRecord();
  }

  searchRecord() {
    this.orderService.getOrdersById(this.recordId).subscribe({
      next: (data: OrderModel) => {
        this.recordId = data.id ?? 0;
        this.recordUserId = data.usuarioId ?? 0;
        this.recordProductId = data.productoId ?? 0;
        this.recordDate = data.fecha ?? new Date();
        this.recordQuantity = data.cantidad ?? 0;
      },
      error: (err: any) => {
        alert('Error: El registro no existe');
        console.log('record: ', this.recordId);
      },
    });
  }

  deleteRecord() {
    this.orderService.deleteOrder(this.recordId).subscribe({
      next: (data: any) => {
        alert('Pedido eliminado correctamente');
        this.router.navigate(['list-orders']);
      },
      error: (err: any) => {
        alert('Ha ocurrido un error');
      },
    });
  }

}

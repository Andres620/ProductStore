import { Component, OnInit } from '@angular/core';
import { OrderModel } from 'src/app/models/orderModel';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-list-order',
  templateUrl: './list-order.component.html',
  styleUrls: ['./list-order.component.css']
})
export class ListOrderComponent implements OnInit{
  orderList: OrderModel[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.orderService.getOrders().subscribe({
      next: (data: OrderModel[]) => {
        this.orderList = data;
        console.log(this.orderList);
      },
      error: (data: any) => {
        alert("Error leyendo la información");
        console.log(this.orderList);
      }
    });
  }

  searchOrderByUserId(id: HTMLInputElement) {
    console.log(id);
    if(isNaN(id.valueAsNumber)){
      this.orderService.getOrders().subscribe({
        next: (data: OrderModel[]) => {
          this.orderList = data;
          console.log(this.orderList);
        },
        error: (data: any) => {
          alert("Error leyendo la información");
          console.log(this.orderList);
        }
      });
    }else{
      this.orderService.getOrdersByUserId(id.valueAsNumber).subscribe({
        next: (data: OrderModel[]) => {
          this.orderList = data;
          console.log(this.orderList);
        },
        error: (data: any) => {
          alert("Error leyendo la información");
          console.log(this.orderList);
        }
      });
    }
  }
}

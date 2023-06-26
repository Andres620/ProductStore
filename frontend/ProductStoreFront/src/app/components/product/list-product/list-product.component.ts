import { Component, OnInit } from '@angular/core';
import { ProductModel } from 'src/app/models/productModel';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit{
  productList: ProductModel[] = [];
  isLoggedin: boolean = false;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (data: ProductModel[]) => {
        this.productList = data;
        console.log(this.productList);
      },
      error: (data: any) => {
        alert("Error leyendo la información");
        console.log(this.productList);
      }
    });
  }
}

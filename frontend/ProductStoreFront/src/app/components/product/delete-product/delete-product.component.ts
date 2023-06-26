import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductModel } from 'src/app/models/productModel';
import { ProductService } from 'src/app/services/product.service';

import 'src/assets/js/mdb.min.js';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {
  recordId: number = 0;
  recordName: string = '';
  recordDescription: string = '';
  recordPrice: number = 0;

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.recordId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.searchRecord();
  }

  searchRecord() {
    this.productService.getProductsById(this.recordId).subscribe({
      next: (data: ProductModel) => {
        this.recordId = data.id ?? 0;
        this.recordName = data.nombre ?? '';
        this.recordDescription = data.descripcion ?? '';
        this.recordPrice = data.precio ?? 0;
      },
      error: (err: any) => {
        alert('Error: El registro no existe');
        console.log('record: ', this.recordId);
      },
    });
  }

  deleteRecord() {
    this.productService.deleteProduct(this.recordId).subscribe({
      next: (data: any) => {
        alert('Producto eliminado correctamente');
        this.router.navigate(['list-products']);
      },
      error: (err: any) => {
        alert('Ha ocurrido un error');
      },
    });
  }
}

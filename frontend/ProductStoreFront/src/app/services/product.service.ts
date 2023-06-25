import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductModel } from '../models/productModel';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private urlApi = 'https://localhost:7009/';
  constructor(private http: HttpClient) {}

  /**
   * Listado de prductos
   * @returns
   */
  public getProducts(): Observable<ProductModel[]> {
    return this.http.get<ProductModel[]>(`${this.urlApi}Producto`);
  }

  /**
   * Obtener producto por id
   * @param id 
   * @returns 
   */
  public getProductsById(id: number): Observable<ProductModel> {
    return this.http.get<ProductModel>(`${this.urlApi}Producto/${id}`);
  }

  /**
   * Guardar producto
   * @param product
   * @returns
   */
  public saveProduct(product: ProductModel): Observable<ProductModel> {
    return this.http.post<ProductModel>(`${this.urlApi}Producto`, product);
  }

  /**
   * Editar producto
   * @param product
   * @returns
   */
  public editProduct(product: ProductModel): Observable<ProductModel> {
    return this.http.put<ProductModel>(`${this.urlApi}Producto/${product.id}`, product);
  }


  /**
   * Eliminar un producto
   * @param id 
   * @returns 
   */
  public deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(`${this.urlApi}Producto/${id}`);
  }
}

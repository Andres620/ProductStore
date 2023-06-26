import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderModel } from '../models/orderModel';


@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private urlApi = 'https://localhost:7009/';
  constructor(private http: HttpClient) {}

  /**
   * Listado de pedidos
   * @returns
   */
  public getOrders(): Observable<OrderModel[]> {
    return this.http.get<OrderModel[]>(`${this.urlApi}Pedido`);
  }

  /**
   * Listado de pedidos por id de usuario
   * @param id 
   * @returns
   */
    public getOrdersByUserId(id: number): Observable<OrderModel[]> {
      return this.http.get<OrderModel[]>(`${this.urlApi}Pedido/usuario/${id}/pedidos`);
    }

  /**
   * Obtener pedido por id
   * @param id 
   * @returns 
   */
  public getOrdersById(id: number): Observable<OrderModel> {
    return this.http.get<OrderModel>(`${this.urlApi}Pedido/${id}`);
  }

  /**
   * Guardar pedido
   * @param order
   * @returns
   */
  public saveOrder(order: OrderModel): Observable<OrderModel> {
    return this.http.post<OrderModel>(`${this.urlApi}Pedido`, order);
  }

  /**
   * Editar pedido
   * @param order
   * @returns
   */
  public editOrder(order: OrderModel): Observable<OrderModel> {
    return this.http.put<OrderModel>(`${this.urlApi}Pedido/${order.id}`, order);
  }


  /**
   * Eliminar un pedido
   * @param id 
   * @returns 
   */
  public deleteOrder(id: number): Observable<any> {
    return this.http.delete<any>(`${this.urlApi}Pedido/${id}`);
  }
}

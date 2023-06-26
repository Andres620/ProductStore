import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserModel } from '../models/userModel';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private urlApi = 'https://localhost:7009/';
  constructor(private http: HttpClient) {}

  /**
   * Listado de usuarios
   * @returns
   */
  public getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(`${this.urlApi}Usuario`);
  }

  /**
   * Obtener usuario por id
   * @param id
   * @returns
   */
  public getUsersById(id: number): Observable<UserModel> {
    return this.http.get<UserModel>(`${this.urlApi}Usuario/${id}`);
  }

  /**
   * Guardar usuario
   * @param user
   * @returns
   */
  public saveUser(user: UserModel): Observable<UserModel> {
    return this.http.post<UserModel>(`${this.urlApi}Usuario`, user);
  }

  /**
   * Editar usuario
   * @param user
   * @returns
   */
  public editUser(user: UserModel): Observable<UserModel> {
    return this.http.put<UserModel>(`${this.urlApi}Usuario/${user.id}`, user);
  }

  /**
   * Eliminar un usuario
   * @param id
   * @returns
   */
  public deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(`${this.urlApi}Usuario/${id}`);
  }

  /**
   * Autenticar usuario
   * @param email 
   * @param password 
   * @returns 
   */
  public autenticateUser(email: string, password: string): Observable<UserModel> {
    return this.http.get(`${this.urlApi}auth/${email}/${password}`);
  }
}

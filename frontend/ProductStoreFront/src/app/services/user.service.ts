import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { UserModel } from '../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private urlApi = 'https://localhost:7009/';

  constructor(private http: HttpClient) { }

  /**
   * Listado de usuarios
   * @returns 
   */
  public getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(`${this.urlApi}Usuario`);
  }
}

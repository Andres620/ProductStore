import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ILogin } from '../models/login.interface';
import { IResponse } from '../models/response.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = 'https://localhost:7009/Usuario';

  constructor(private http: HttpClient) { }

  loginByEmail(form: ILogin): Observable<IResponse> {
    let direction = this.urlApi + 'Usuario';
    return this.http.post<IResponse>(direction, form);
  };

  public getUsuarios(): Observable<any> {
    return this.http.get(this.urlApi);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = 'https://localhost:7009/Usuario';

  constructor(private http: HttpClient) { }

  public getUsuarios(): Observable<any> {
    return this.http.get(this.urlApi);
  }
}

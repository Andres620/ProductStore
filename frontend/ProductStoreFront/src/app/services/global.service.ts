import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  private _globalAutenticated = new BehaviorSubject<boolean>(false);

  get globalVariable(): BehaviorSubject<boolean> {
    return this._globalAutenticated;
  }

  set globalVariable(value: boolean) {
    this._globalAutenticated.next(value);
  }
}

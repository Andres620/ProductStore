import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GlobalService } from '../services/global.service';

@Injectable()
export class AuthGuard  {
  isLoggedin: boolean = false;
  constructor(private router: Router, private globalService: GlobalService) {}

  canActivate(): boolean {
    this.globalService.globalVariable.subscribe((value) => {
      this.isLoggedin = value;
    });
    if (this.isLoggedin) {
      return true;
    } else {
      this.router.navigate(['/auth']);
      return false;
    }
  }
}

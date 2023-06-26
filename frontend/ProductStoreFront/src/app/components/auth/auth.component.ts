import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/services/global.service';
import 'src/assets/js/mdb.min.js'; 

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  isLoggedin: boolean = false;

  constructor(
    private globalService: GlobalService
  ) {}
  
  ngOnInit(): void {
    this.globalService.globalVariable.subscribe(value => {
      this.isLoggedin = value;
    });
  }

}

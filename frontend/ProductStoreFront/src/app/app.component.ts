import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'ProductStoreFront';
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

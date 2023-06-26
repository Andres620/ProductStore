import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/services/global.service';
import { LoadScriptsService } from 'src/app/services/load-scripts.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit{
  isLoggedin: boolean = false;
  constructor(
    private _loadScripts: LoadScriptsService,
    private globalService: GlobalService
  ) {
    _loadScripts.load(['sidebar/sidebar']);
  }

  ngOnInit(): void {
    this.globalService.globalVariable.subscribe(value => {
      this.isLoggedin = value;
    });
  }

  logout(){
    this.globalService.globalVariable.next(false);
    this.globalService.globalVariable.subscribe(value => {
      this.isLoggedin = value;
    });
  }
}

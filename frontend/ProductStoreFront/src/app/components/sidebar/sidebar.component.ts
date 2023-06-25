import { Component } from '@angular/core';
import { LoadScriptsService } from 'src/app/services/load-scripts.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  

  constructor(private _loadScripts: LoadScriptsService) {
    _loadScripts.load(["sidebar/sidebar"]);
   }
}

import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit {
  data: any[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.fillData();
  }

  fillData() {
    this.apiService.getUsuarios().subscribe((data) => {
      this.data = data;
      console.log(this.data);
    });
  }
}

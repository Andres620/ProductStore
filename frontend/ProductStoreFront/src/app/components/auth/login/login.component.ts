import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from '../../../services/api.service';
import { ILogin } from 'src/app/models/login.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  loginForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.pattern('[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+')]),
    password : new FormControl('', Validators.required)
  });

  constructor(private api: ApiService) { }

  ngOnInit(): void {

  }

  onLogin(form: ILogin){
    this.api.loginByEmail(form).subscribe(data => {
      console.log(data);
    })
  }

}

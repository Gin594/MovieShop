import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin:Login = {
    email: '', password: ''
  }
  constructor() { }

  ngOnInit(): void {

  }

  login(){
    console.log(this.userLogin.email);
  }
}

import { Component } from '@angular/core';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  // get the data from the email and password fields and send it to the server when the user clicks the login button
  loginEmail: any = '';
  constructor(private login: LoginService) {}
  LoginButton() 
  {
    //this is getting the data from the server
    this.login.getLogin().subscribe(data => {this.loginEmail = data.mytoken;});
  }
}

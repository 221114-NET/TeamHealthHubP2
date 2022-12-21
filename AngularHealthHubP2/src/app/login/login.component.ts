import { Component } from '@angular/core';
import { tap } from 'rxjs';
import { AuthToken, LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginEmail: string = "";
  loginPassword: string = "";


  constructor(private login: LoginService) {}
  
  async LoginButton(loginEmail: string, loginPassword: string) 
  {
    
    // const resp = await this.login.getLogin(loginEmail, loginPassword).toPromise();
    //   sessionStorage.setItem("auth", resp.mytoken)
    
    this.login.getLogin(loginEmail, loginPassword).subscribe(data => 
      {
      sessionStorage.setItem("auth", data.mytoken)
      //TODO ask about this since i am not async this.myString = data.mytoken
      //TODO check if the retun value is user not found if it is display that else save it in sessionStorage
      });

  }


}

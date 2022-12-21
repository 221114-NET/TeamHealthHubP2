import { Component } from '@angular/core';
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
    console.log(loginEmail);
    console.log(loginPassword);
    let LoginOutput: string = "";

    LoginOutput = (await this.login.getLogin(loginEmail, loginPassword)).mytoken;

    sessionStorage.setItem("auth", LoginOutput);
    

    // .subscribe(data => 
    //   {
    //   sessionStorage.setItem("auth", data.mytoken)
    //   //TODO ask about this since i am not async this.myString = data.mytoken
    //   //TODO check if the retun value is user not found if it is display that else save it in sessionStorage
    //   });

  }


}

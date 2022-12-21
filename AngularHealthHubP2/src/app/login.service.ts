import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {

  }
  private loginUrl = 'http://localhost:5122/api/Api/User/Login';  // URL to web api
  

  async getLogin(loginEmail: string, loginPassword: string): Promise<AuthToken>{
    
    return await lastValueFrom(this.http.post<AuthToken>(this.loginUrl, {"email": `${loginEmail}`,"password": `${loginPassword}`},));
    
  }
  
}
export interface AuthToken  {
  mytoken: string;
}

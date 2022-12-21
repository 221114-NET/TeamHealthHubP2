import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { config, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {

  }
  private loginUrl = 'http://localhost:5122/api/Api/User/Login';  // URL to web api
  

  getLogin(loginEmail: string, loginPassword: string): Observable<AuthToken>{
    
    return this.http.post<AuthToken>(this.loginUrl, {"email": `${loginEmail}`,"password": `${loginPassword}`},);
  }
  
}
export interface AuthToken {
  mytoken: string;
}

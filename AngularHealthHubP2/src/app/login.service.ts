import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { config, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {

  }
  private mytoken = '';
  private loginUrl = 'http://localhost:5122/api/Api/User/Login';  // URL to web api
  // /** GET heroes from the server */
  // getLogin2(): void {
  //   // this.http.post<string>(this.loginUrl, {"email": "test","password": "test"});
  // }
  
  
  getLogin(): Observable<Config>{
    // now returns an Observable of string
    return this.http.post<Config>(this.loginUrl, {"email": "test","password": "test"},);
  }
  
}
export interface Config {
  mytoken: string;
}

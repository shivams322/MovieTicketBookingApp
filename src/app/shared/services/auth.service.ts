import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router:Router,private http:HttpClient) { }

  proceedLogin(usercred:any):Observable<any>{
    return this.http.post("https://localhost:7130/api/Auth/login",usercred);
  }

  getToken(){
    return sessionStorage.getItem('token');
  }

  getUserId(){
    return sessionStorage.getItem('userid')||'';
  }

  isLoggedIn() {
    return this.getToken() !== null;
  }

  logout() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userid');
    this.router.navigate(['login']);
  }

}

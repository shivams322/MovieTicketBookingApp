import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly APIUrl ="https://localhost:7130/api/User";
  constructor(private http:HttpClient) { }

  getuser(usercred:any):Observable<any>{
    return this.http.post<any>(`${this.APIUrl}/user`,usercred);
  }

  registerUser(user:any):Observable<any>{
    return this.http.post<any>(`${this.APIUrl}/signUp`,user);
  }
}

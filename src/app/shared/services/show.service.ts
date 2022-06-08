import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowService {
  readonly APIUrl ="https://localhost:7130/api/Show";
  constructor(private http:HttpClient) { }

  getShow(id:number):Observable<any[]>{
    return this.http.get<any>(`${this.APIUrl}/movie/shows/${id}`);
  }

  getAllShows():Observable<any[]>{
    return this.http.get<any>(`${this.APIUrl}/allShows`);  
  }

  getcinemaseats(id:number):Observable<any>{
    return this.http.get<any>(`${this.APIUrl}/totalseats/${id}`);
  }

}

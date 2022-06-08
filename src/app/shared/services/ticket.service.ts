import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  readonly APIUrl ="https://localhost:7130/api/Ticket";
  constructor(private http:HttpClient) { }

  bookTicket(booking: Booking):Observable<any>{
    return this.http.post(`${this.APIUrl}/bookTicket`,booking);
  }

  showTicket(id:any,showId:any):Observable<any[]>{
    return this.http.get<any>(`${this.APIUrl}/ticket/${id}/${showId}`);
  }

  seatStatus(showId:any):Observable<any[]>{
    return this.http.get<any>(`${this.APIUrl}/seatstatus/${showId}`);
  }

  showAllTickets(userId:number):Observable<any[]>{
    return this.http.get<any>(`${this.APIUrl}/alltickets/${userId}`);
  }
}

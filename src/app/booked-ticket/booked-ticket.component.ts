import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Ticket } from '../shared/models/ticket.model';
import { AuthService } from '../shared/services/auth.service';
import { TicketService } from '../shared/services/ticket.service';
@Component({
  selector: 'app-booked-ticket',
  templateUrl: './booked-ticket.component.html',
  styleUrls: ['./booked-ticket.component.scss']
})
export class BookedTicketComponent implements OnInit {

  constructor(private route:ActivatedRoute,private service:TicketService,private authService:AuthService) { }
  
  showid:number;
  tickets:Ticket[];

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap)=>{
      let id = params.get('id') as any as number;
      this.showid = id;
      this.showTicket(this.showid);
    });
  }

  showTicket(showid:any){
    this.service.showTicket(parseInt(this.authService.getUserId()),showid).subscribe(data=>{
      this.tickets=data;
    });
  }

}

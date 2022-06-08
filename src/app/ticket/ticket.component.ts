import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Ticket } from '../shared/models/ticket.model';
import { AuthService } from '../shared/services/auth.service';
import { TicketService } from '../shared/services/ticket.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {

  items: any[] = [
    { id: 1, name: 'All time' },
    { id: 2, name: 'Last 1 day' },
    { id: 3, name: 'Last 1 week' },
    { id: 4, name: 'Last 30 days' },
    { id: 5, name: 'Last 6 months' },
    { id: 6, name: 'Last 1 year' }
  ];
  selected: number = 1;

  constructor(private route:ActivatedRoute,private service:TicketService,private authService:AuthService) { }
  Ticket:Ticket[];
  tickets:Ticket[];
  ngOnInit(): void {
      this.showAllTickets(parseInt(this.authService.getUserId()));
      this.selectOption();
  }


  showAllTickets(userId:number){
    this.service.showAllTickets(userId).subscribe(data=>{
      this.tickets=data;
      this.Ticket=data;
    })
  }

  selectOption() {
    var d = new Date();
    var id=Number(this.selected);
    switch (id) { 
      case 1:
        this.tickets=this.Ticket;
        break;
      case 2:
        d.setDate(d.getDate()-1);
        this.getTicketWithinTimePeriod(d);
        break;
      case 3:
        d.setDate(d.getDate()-7);
        this.getTicketWithinTimePeriod(d);
        break;
      case 4:
        d.setMonth(d.getMonth() - 1);
        this.getTicketWithinTimePeriod(d);
        break;
      case 5:
        d.setMonth(d.getMonth() - 6);
        this.getTicketWithinTimePeriod(d);
        break;
      case 6:
        d.setMonth(d.getMonth() - 12);
        this.getTicketWithinTimePeriod(d);
        break;

    }
     
  }

  getTicketWithinTimePeriod(d:any){
    var tickets = Array<Ticket>();
      this.Ticket?.forEach(ticket=>{
        var date = new Date(ticket.movieTimings);
        if(date>d){
          tickets.push(ticket);
        }
      });
      this.tickets=tickets;
  }
}

import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router , ParamMap} from '@angular/router';
import { Show } from '../shared/models/show.model';
import { AuthService } from '../shared/services/auth.service';
import { ShowService } from '../shared/services/show.service';
import { TicketService } from '../shared/services/ticket.service';

@Component({
  selector: 'app-shows-list',
  templateUrl: './shows-list.component.html',
  styleUrls: ['./shows-list.component.scss']
})
export class ShowsListComponent implements OnInit {

  constructor(private service:ShowService,private ticketService:TicketService,
    private route:ActivatedRoute,private router:Router,private authService:AuthService) { }
  
  movieShowsList:Array<Show>=[];
  show:Show;
  selectedSeat:Array<number>=[];
  totalSeatNumber:number=0;
  columns:number[] = new Array(10);
  rows:any = [];
  seatStructure:any=[];
  display:boolean=false;
  
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap)=>{
      let id = params.get('id');
      this.getShows(id);
    });
  }

  getShows(id: any){
    this.service.getShow(id).subscribe(data=>{
      this.movieShowsList=data;
    })
  }

  bookTicket(show:Show){
    this.show=show;
    this.service.getcinemaseats(this.show.cinemaId).subscribe(totalseats=>{
      this.totalSeatNumber=totalseats;
      this.rows=new Array((totalseats/this.columns.length));
    });
    this.ticketService.seatStatus(this.show.id).subscribe(data=>{
      this.seatStructure=data;
      this.display=true;
    });
  }

  onSeatSelect(seatNum:number){
    if(!this.selectedSeat.includes(seatNum)){
      this.selectedSeat.push(seatNum);
    }
    else{
      var index = this.selectedSeat.indexOf(seatNum);
      this.selectedSeat.splice(index,1);
    }
  }

  ticketBooking(){
    let booking = {userId:parseInt(this.authService.getUserId()),showId:this.show.id,
                    noOfSeats:this.selectedSeat.length,seatNumbers:this.selectedSeat}

    this.ticketService.bookTicket(booking).subscribe(response=>{
      if(response==false){
        alert("You may have selected a booked seat");
        this.ticketService.seatStatus(this.show.id).subscribe(data=>{
          this.seatStructure=data;
        })
      }
      else{
        this.router.navigate(['movies',this.show.movieId,'shows',booking.showId]);
      }
    });
  }

  isSeatSelected(seatNumber:number){
    return this.selectedSeat.some((s: number)=> s==seatNumber);
  }

  bookedSeat(seatNum:number){
    return !this.seatStructure.some((s: { seatNumber: number; })=>s.seatNumber==seatNum)
  }

  close(){
    this.display=false;
  }

}

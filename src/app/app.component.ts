import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Movie } from './shared/models/movie.model';
import { AuthService } from './shared/services/auth.service';
import { MoviesService } from './shared/services/movies.service';
import { TicketService } from './shared/services/ticket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BookMyShowApp';
  display:boolean=false;
  movies:Array<Movie>=[];
  myControl = new FormControl();
  filteredOptions: any;
  constructor(private router:Router,private authService:AuthService,private ticketService:TicketService,private movieService:MoviesService){}
  
  searchBar = new FormGroup({
    searchText: new FormControl('',Validators.required)
  });

  ngOnInit(): void {
    if(this.authService.getToken()){
      this.display=true;
    }
    this.getAllMovies();
  }
  signout(){
    this.authService.logout();
    this.display=false;
  }

  getAllMovies(){
    this.movieService.getMovies().subscribe(data=>this.movies=data);
  }

  searchThis(){
    this.movieService.getMovies().subscribe(data=>this.movies=data);
    console.log(this.movies);
    console.log(this.searchBar.controls['searchText'].value);
    if(this.movies.some((m: { title: any; })=>(m.title).toLowerCase()==(this.searchBar.controls['searchText'].value).toLowerCase())){
      this.router.navigate([this.searchBar.controls['searchText'].value]);
    }
    else if(this.searchBar.controls['searchText'].value==""){
      this.router.navigate(['movies']);
    }
  }

}

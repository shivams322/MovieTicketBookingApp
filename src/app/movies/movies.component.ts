import { Component, OnInit, Output,EventEmitter } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Movie } from '../shared/models/movie.model';
import { MoviesService } from '../shared/services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  
  constructor(public service: MoviesService,private router:Router,private route:ActivatedRoute) { }

  movieList:Movie[]=[];
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap)=>{
      let movieName = params.get('movie') as any as string;
      if(movieName==null){
        this.getMovieList();
      }
      else{
        this.showSearchedMovie(movieName);
      }
    });
    
  }

  getMovieList(){
    this.service.getMovies().subscribe(data=>{
      this.movieList=data;
    });  
  }

  showSearchedMovie(name:string){
    this.service.getMovies().subscribe(data=>{
      data.forEach(element => {
        if((element.title).toLowerCase()==(name).toLowerCase()){
          this.movieList.push(element);
        }
      });
    })
  }

}

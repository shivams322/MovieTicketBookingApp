import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Movie } from '../shared/models/movie.model';
import { MoviesService } from '../shared/services/movies.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
})
export class MovieDetailsComponent implements OnInit {

  constructor(
    private service: MoviesService,
    private route: ActivatedRoute,
    private router: Router,
    private _sanitizer: DomSanitizer
  ) {}

  movieDetails: Movie;
  movieId: any;
  imgStr: string;
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id');
      this.movieId = id;
      this.showMovieDetail(id);
    });
  }

  showMovieDetail(id: any) {
    this.service.getMovieDetail(id).subscribe((movie) => {
      this.movieDetails = movie;
      this.imgStr = movie.movieImage;
    });
  }
}

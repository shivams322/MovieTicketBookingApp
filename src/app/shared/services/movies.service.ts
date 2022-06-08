import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie.model';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  readonly APIUrl ="https://localhost:7130/api/Movie";
  constructor(private http:HttpClient) { }
  
  getMovies():Observable<Movie[]>{
    return this.http.get<any>(`${this.APIUrl}/allMovies`);
  }

  getMovieDetail(id:any):Observable<Movie>{
    return this.http.get<Movie>(`${this.APIUrl}/movieDetail/${id}`);
  }
  addMovies(val:any){                                        
    return this.http.post(`${this.APIUrl}/addMovie`,val);
  }

  getMovieImage(movieId:number):Observable<any>{
    return this.http.get<any>(`https://localhost:7130/api/Image/${movieId}`);
  }
}

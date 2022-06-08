import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesComponent } from './movies/movies.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { ShowsListComponent } from './shows-list/shows-list.component';
import { LoginComponent } from './login/login.component';
import { MoviesService } from './shared/services/movies.service';
import { ShowService } from './shared/services/show.service';
import { AuthService } from './shared/services/auth.service';
import { TokenInterceptorService } from './shared/services/token-interceptor.service';
import { TicketService } from './shared/services/ticket.service';
import { TicketComponent } from './ticket/ticket.component';
import { RegisterComponent } from './register/register.component';
import { BookedTicketComponent } from './booked-ticket/booked-ticket.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviesComponent,
    MovieDetailsComponent,
    ShowsListComponent,
    LoginComponent,
    TicketComponent,
    RegisterComponent,
    BookedTicketComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [MoviesService,ShowService,AuthService,TicketService,{provide: HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }

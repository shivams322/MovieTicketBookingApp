import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookedTicketComponent } from './booked-ticket/booked-ticket.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MoviesComponent } from './movies/movies.component';
import { RegisterComponent } from './register/register.component';
import { ShowsListComponent } from './shows-list/shows-list.component';
import { TicketComponent } from './ticket/ticket.component';

const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'movies',canActivate:[AuthGuard],component:MoviesComponent},
  {path:'ticket',canActivate:[AuthGuard],component:TicketComponent},
  {path:':movie',canActivate:[AuthGuard],component:MoviesComponent},
  {path:'movies/:id',canActivate:[AuthGuard],component:MovieDetailsComponent},
  {path:'movies/:id/shows',canActivate:[AuthGuard],component:ShowsListComponent},
  {path:'movies/:id/shows/:id',canActivate:[AuthGuard],component:BookedTicketComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

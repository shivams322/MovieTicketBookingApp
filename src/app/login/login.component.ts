
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';
import { AuthService } from '../shared/services/auth.service';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    email:new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required])
  });
  constructor(private service: AuthService,private router:Router,private userService:UserService,private appcomp:AppComponent) { }
  
  responsedata: any;
  ngOnInit(): void {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.service.proceedLogin(this.loginForm.value).subscribe(result => {
        if(result!=null){
          this.responsedata= result;
          this.userService.getuser(this.loginForm.value).subscribe(data=>{
             sessionStorage.setItem('userid',data.id);
          });
          sessionStorage.setItem('token',this.responsedata.token);
          this.router.navigate(['movies'])
          this.appcomp.display=true;
        }
      });
    }
  }


}

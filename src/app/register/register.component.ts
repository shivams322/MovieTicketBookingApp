import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm = new FormGroup({
    name: new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required,Validators.pattern('([a-z0-9_\._]+)@([a-z0-9])+.([a-z]+)(.[a-z]+)')]),
    phone: new FormControl('',[Validators.required,Validators.pattern('[0-9]{10}')]),
    password: new FormControl('',Validators.required)
  });

  constructor(private userService: UserService,private router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    if(this.registerForm.valid){
      console.log(this.registerForm);
      this.userService.registerUser(this.registerForm.value).subscribe();
      alert("You are Successfully Registered")
      this.router.navigate(['login']);
    }
  }

}

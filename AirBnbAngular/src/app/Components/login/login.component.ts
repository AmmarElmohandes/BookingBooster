import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private router:Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {}
    invalidLogin = false;
  form = new FormGroup({
    Email: new FormControl('',Validators.required),
    Password: new FormControl('',Validators.required),
  });
  login(){
    let credentials = this.form.value;
    this.authService.logIn(credentials)
    .subscribe(result =>{
      if(result>0)
      {
      console.log(result)
      this.router.navigate(['']);
      }
      this.invalidLogin = true;
    });

  }
}
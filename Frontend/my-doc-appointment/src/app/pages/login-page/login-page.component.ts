import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/user-logging/login.service';
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  loginForm = true;
  signInForm : FormGroup;
  signUpForm : FormGroup;

  signInState = {
    loading : false,
    success : false
  }

  signUpState = {
    loading : false,
    success : false
  }

  constructor (private fg : FormBuilder, private router : Router, private loginService : LoginService){
  }

  ngOnInit(){
    this.signInForm = this.fg.group({
      email: '',
      password: ''
    });
    this.signUpForm = this.fg.group({
      email: '',
      name: '',
      birthdate: '',
      password: ''
    })
    this.signInForm.valueChanges.subscribe();
    this.signUpForm.valueChanges.subscribe();
  }

  cycleForm():void{
    this.loginForm = !this.loginForm;
  }

  signInSubmit(){
    console.log(this.signInForm.value);
    this.logIn();
  }

  signUpSubmit(){
    console.log(this.signUpForm.value);
  }

  logIn(){
    if(this.signInForm.value.email == 'admin@admin.admin' && this.signInForm.value.password == 'admin'){
      this.loginService.publishState(2);
      this.router.navigate(['/admin']);
    }
    else if(this.signInForm.value.email === 'client@client.client' && this.signInForm.value.password === 'client'){
      this.loginService.publishState(1);
      this.router.navigate(['/appointment']);
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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

  constructor (private fg : FormBuilder){
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
  }

  signUpSubmit(){
    console.log(this.signUpForm.value);
  }
}

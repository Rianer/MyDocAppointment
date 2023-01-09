import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/user-logging/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(private status: LoginService, private router: Router){

  }
  ngOnInit(): void {
    if(this.status.loggedStatus === 0){
      this.router.navigate(['']);
    }
  }
  title = 'my-doc-appointment';
  loggedUserState : number = 0;
}

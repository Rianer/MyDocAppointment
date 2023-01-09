import { Component, Input, OnInit } from '@angular/core';
import { Event, NavigationEnd, Router } from '@angular/router';
import { LoginService } from '../services/user-logging/login.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  logStatus : number;
  selectedLink : string;


  constructor(private router : Router, private loginService : LoginService){
    this.router.events.subscribe((event : Event)=>{
      if (event instanceof NavigationEnd){
        this.selectedLink = event.url;
        console.log(this.selectedLink);
      }
    });
  }

  ngOnInit(): void {
    this.loginService.status.subscribe(status => {
      this.logStatus = status;
    });
  }
}

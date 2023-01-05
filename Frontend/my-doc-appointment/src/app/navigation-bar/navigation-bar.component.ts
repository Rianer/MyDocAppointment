import { Component, OnInit } from '@angular/core';
import { Event, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  selectedLink : string;

  constructor(private router : Router){
    this.router.events.subscribe((event : Event)=>{
      if (event instanceof NavigationEnd){
        this.selectedLink = event.url;
        console.log(this.selectedLink);
      }
    });
  }

  ngOnInit(): void {
  }
}

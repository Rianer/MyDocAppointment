import { style, transition, trigger, animate, state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/user-logging/login.service';
export type FadeState = 'visible' | 'hidden';
@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
})
export class AdminPageComponent implements OnInit {
  showImageMenu : boolean;
  showDetails : boolean;

  constructor(private loginService : LoginService, private router: Router){

  }

  ngOnInit(): void {
    this.showImageMenu = false;
    this.showDetails = false;
  }

  toggleImageMenu() : void{
    this.showImageMenu = !this.showImageMenu;
  }

  toggleDetails() : void{
    this.showDetails = !this.showDetails;
  }

  updateDetails() : void{
    this.showDetails = false;
  }

  displayingTableTab : number = 0;

  changeTableTab(tabIndex:number):void{
    this.displayingTableTab = tabIndex;
  }

  logOut(){
    this.loginService.publishState(0);
    this.router.navigate(['']);
  }
}

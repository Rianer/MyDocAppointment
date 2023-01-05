import { style, transition, trigger, animate, state } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
export type FadeState = 'visible' | 'hidden';
@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss'],
})
export class AdminPageComponent implements OnInit {
  showImageMenu : boolean;
  showDetails : boolean;

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
}

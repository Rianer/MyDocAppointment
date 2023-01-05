import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'doctors-table',
  templateUrl: './doctors-table.component.html',
  styleUrls: ['./doctors-table.component.scss']
})
export class DoctorsTableComponent implements OnInit {
  
  showSidebarMenu : boolean;

  ngOnInit(): void {
    this.showSidebarMenu = false;
  }

  clickedWhiteSpace(event : Event){
    const className = (event.target as Element).className;
    if(className === 'sidebar-menu'){
      this.toggleSidebarMenu();
    }
  }

  toggleSidebarMenu(){
    this.showSidebarMenu = !this.showSidebarMenu;
  }

  openSidebarMenu(){
    this.showSidebarMenu = true;
  }
}

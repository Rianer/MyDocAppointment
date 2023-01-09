import { Component } from '@angular/core';

@Component({
  selector: 'appointments-table',
  templateUrl: './appointments-table.component.html',
  styleUrls: ['./appointments-table.component.scss']
})
export class AppointmentsTableComponent {
  editModeActive : boolean = false;

  toggleEditMode():void{
    this.editModeActive = !this.editModeActive;
  }
}

import { Component, OnInit } from '@angular/core';
import { Appointment, NewAppointment } from 'src/app/models/appointment.model';
import { AppointmentsService } from 'src/app/services/appointments/appointments.service';
import { DoctorsServiceService } from 'src/app/services/doctors-service.service';

@Component({
  selector: 'appointments-table',
  templateUrl: './appointments-table.component.html',
  styleUrls: ['./appointments-table.component.scss']
})
export class AppointmentsTableComponent implements OnInit {
  
  editModeActive : boolean = false;
  appointmentList : Appointment[];

  constructor(private appointmentService : AppointmentsService, private doctorService : DoctorsServiceService){
  }

  ngOnInit(): void {
    this.appointmentService.getAll().subscribe((response) => {
      this.appointmentList = response;
      console.log(this.appointmentList);
      this.appointmentList.forEach((element) => {
        this.doctorService.getDoctorById(element.doctorID).subscribe((response) => {
          element.doctorName = response.surname + ' ' + response.name;
        });
      });
    });
    
  }

  toggleEditMode():void{
    this.editModeActive = !this.editModeActive;
  }
}

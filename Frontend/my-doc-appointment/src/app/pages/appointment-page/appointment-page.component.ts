import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewAppointment } from 'src/app/models/appointment.model';
import { MatDialog } from '@angular/material/dialog';
import { AddAppointmentComponent } from 'src/app/components/add-appointment/add-appointment.component';
import { Appointment } from 'src/app/models/appointment.model';
import { AppointmentsService } from 'src/app/services/appointments/appointments.service';
import { LoginService } from 'src/app/services/user-logging/login.service';
import { DoctorsServiceService } from 'src/app/services/doctors-service.service';
import { Router } from '@angular/router';
import { Doctor } from 'src/app/models/doctor.model';

@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrls: ['./appointment-page.component.scss']
})
export class AppointmentPageComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    private appointmentService : AppointmentsService,
    private doctorService : DoctorsServiceService,
    private loginService: LoginService,
    private router : Router
    ) {}

  appointmentHistory : Appointment[] = [];
  doctors : Doctor[];
  // lastDoctorName : string;

  ngOnInit(): void {
    this.loginService.getLoggedUser().subscribe((response) => {
      const user = response[0];
      this.loginService.userId = user.id;
      this.appointmentService.getAll().subscribe((response) => {
        this.doctorService.getAllDoctors().subscribe((doctors) => {
          this.doctors = doctors;
          response.forEach((element) => {
            if(element.patientID === this.loginService.userId){
              this.appointmentHistory.push(element);
              this.doctors.forEach((doctor) => {
                if(doctor.id === element.doctorID){
                  const lastDoctorName = doctor.surname + ' ' + doctor.name;
                  element.doctorName = lastDoctorName;
                }
              });
            }
          });
        })
      });
    })
    
  }
  
  openDialog() {
    this.dialog.open(AddAppointmentComponent).afterClosed();
  }

  showDoctor(){
    this.router.navigate(['doctors']);
  }
  showImageMenu : boolean;
  toggleImageMenu() : void{
    this.showImageMenu = !this.showImageMenu;
  }
  logOut(){
    this.loginService.publishState(0);
    this.router.navigate(['']);
  }
}

import { Component, OnInit } from '@angular/core';
import { Appointment, NewAppointment } from 'src/app/models/appointment.model';
import { Doctor } from 'src/app/models/doctor.model';
import { Patient } from 'src/app/models/patient.model';
import { AppointmentsService } from 'src/app/services/appointments/appointments.service';
import { DoctorsServiceService } from 'src/app/services/doctors-service.service';
import { PatientsService } from 'src/app/services/patients/patients.service';

@Component({
  selector: 'appointments-table',
  templateUrl: './appointments-table.component.html',
  styleUrls: ['./appointments-table.component.scss']
})
export class AppointmentsTableComponent implements OnInit {
  
  editModeActive : boolean = false;
  appointmentList : Appointment[];
  allDoctors : Doctor[];
  allPatients : Patient[];

  constructor(
    private appointmentService : AppointmentsService, 
    private doctorService : DoctorsServiceService,
    private patientService : PatientsService
    ){
  }

  ngOnInit(): void {
    this.loadTable();
  }

  loadTable():void{
    this.appointmentService.getAll().subscribe((response) => {
      this.appointmentList = response;
      
      this.doctorService.getAllDoctors().subscribe((doctors) => {
        this.allDoctors = doctors;

        this.patientService.getAll().subscribe((patients) => {
          this.allPatients = patients;

          this.appointmentList.forEach((element) => {
            this.allDoctors.forEach((doctor) => {
              if(doctor.id === element.doctorID){
                element.doctorName = doctor.surname + ' ' + doctor.name;
              }
            });
            this.allPatients.forEach((patient) => {
              element.patientName = patient.name + ' ' + patient.surname;
            });          
          });

          console.log(this.appointmentList);
        })
        
      });
      
    });
  }

  toggleEditMode():void{
    this.editModeActive = !this.editModeActive;
  }

  deleteAppointment(id : string, allowDelete: boolean):void{
    if(allowDelete){
      this.appointmentService.deleteById(id).subscribe((res) => {
        this.loadTable();
      });
    }
  }
}

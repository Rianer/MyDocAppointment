import { Component, Input, OnInit } from '@angular/core';
import { Doctor, NewDoctor, UpdatedDoctor } from 'src/app/models/doctor.model';
import { DoctorsServiceService } from 'src/app/services/doctors-service.service';

@Component({
  selector: 'doctors-table',
  templateUrl: './doctors-table.component.html',
  styleUrls: ['./doctors-table.component.scss']
})
export class DoctorsTableComponent implements OnInit {
  
  @Input() isAdminPage : boolean = false;
  showSidebarDetails : boolean;
  showSidebarCreate : boolean;
  doctorsList : Doctor[];
  currentDoctor : Doctor;

  updateDoctorForm : UpdatedDoctor;
  createDoctorForm : NewDoctor;

  constructor(private doctorService : DoctorsServiceService){}

  ngOnInit(): void {
    this.fetchDoctorList();
    this.showSidebarDetails = false;
    this.showSidebarCreate = false;
    this.createDoctorForm = new NewDoctor();
  }

  fetchDoctorList(){
    this.doctorService.getAllDoctors().subscribe((doctors) => {
      this.doctorsList = doctors;
    });
  }

  clickedWhiteSpace(event : Event){
    const className = (event.target as Element).className;
    if(className === 'sidebar-menu'){
      this.closeSidebarDetails();
      this.closeCreateSidebar();
    }
  }

  //Update Doctor

  closeSidebarDetails(){
    this.showSidebarDetails = false;
  }

  openSidebarDetails(doctor : Doctor){
    this.showSidebarDetails = true;
    this.currentDoctor = doctor;
    this.updateDoctorForm = new UpdatedDoctor();
  }

  applyDoctorUpdate(){
    this.updateDoctorForm.completeInfo(this.currentDoctor);
    this.doctorService.updateDoctor(this.currentDoctor.id, this.updateDoctorForm).subscribe((response)=>{
      console.log(response);
      this.fetchDoctorList();
    });
    this.closeSidebarDetails();
  }

  //Create Doctor

  openCreateSidebar(){
    this.showSidebarCreate = true;
    this.createDoctorForm = new NewDoctor();
  }

  closeCreateSidebar(){
    this.fetchDoctorList();
    this.showSidebarCreate = false;
  }

  createDoctor(){
    if(this.createDoctorForm.isComplete()){
      this.doctorService.createDoctor(this.createDoctorForm).subscribe((response)=>{
        console.log(response);
        this.fetchDoctorList();
      });
      this.closeCreateSidebar();
    }
  }


  //Delete doctor
  deleteDoctor(){
    this.doctorService.deleteDoctor(this.currentDoctor.id).subscribe((response)=>{
      console.log(response);
      this.fetchDoctorList();
      this.closeSidebarDetails();
    });
  }
  

  
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor.model';
import { ServerResponse } from 'src/app/models/server-response.model';
import { OverlayToggleService } from 'src/app/services/overlay-toggle/overlay-toggle.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
  adminImagePath : string = '';
  showDetails:boolean = false;
  allDoctors : any;
  currentDoctor : any;
  displayedDoctor : any;
  
  constructor(private http: HttpClient, private overlayToggle : OverlayToggleService){}

  async ngOnInit() {
    await this.getDoctors();
  }
  
  async getCurrentDoctor(){ //Get a specific doctor, yet to be implemented
    this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor/40613a52-0d39-4c6c-b79f-08dad85a62f9').subscribe(response => {
      this.currentDoctor = response;
      console.log(this.currentDoctor);
    });
  }

  async getDoctors(){
    this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor').subscribe(response => {
      this.allDoctors = response;
      this.currentDoctor = this.allDoctors[0];
    });
  }

  isTheSameDoctor(doc1:Doctor, doc2:Doctor) : boolean{
    return doc1.id == doc2.id;
  }

  showOverlay(doctor : Doctor){
    this.displayedDoctor = doctor;
    this.overlayToggle.buttonClicked(1);
  }

  createDoctor(){
    this.overlayToggle.buttonClicked(2);
  }

}

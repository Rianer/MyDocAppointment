import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor.model';
import { ServerResponse } from 'src/app/models/server-response.model';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
  adminImagePath : string = '';
  allDoctors : any;
  currentDoctor : any;

  constructor(private http: HttpClient){}

  async ngOnInit() {
    await this.getCurrentDoctor();
    await this.getDoctors();
  }
  
  async getCurrentDoctor(){
    const doc = await this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor/40613a52-0d39-4c6c-b79f-08dad85a62f9').subscribe(response => {
      this.currentDoctor = response;
      console.log(this.currentDoctor);
    });
  }

  async getDoctors(){
    const docs = await this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor').subscribe(response => {
      this.allDoctors = response;
    });
  }

  isTheSameDoctor(doc1:Doctor, doc2:Doctor) : boolean{
    return doc1.id == doc2.id;
  }

}

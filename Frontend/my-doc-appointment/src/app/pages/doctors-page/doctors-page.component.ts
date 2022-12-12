import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerResponse } from 'src/app/models/server-response.model';
import { Doctor } from 'src/app/models/doctor.model';

@Component({
  selector: 'app-doctors-page',
  templateUrl: './doctors-page.component.html',
  styleUrls: ['./doctors-page.component.scss']
})
export class DoctorsPageComponent implements OnInit {
  

  doctors1 = [
    {
      name:'Peter Parker',
      email:'p.parker@gmail.com',
      speciality:'Spiderman'
    },
    {
      name:'Steven Strange',
      email:'steven.strange@marvel.com',
      speciality:'Surgeon'
    },
  ];
  data : any;
  doctors : any;

  constructor(private http: HttpClient ){}


  ngOnInit() {
    this.getDoctors();
  }

  showDoctors(){
    console.log(this.doctors);
  }

  async getDoctors(){
    const docs = await this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor').subscribe(response => {
      console.log(response);
      this.doctors = response;
      console.log(this.doctors);
    });
    // this.doctors = docs;
    // console.log(this.doctors);
  }
}

import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

  constructor(private http: HttpClient ){

  }


  async ngOnInit() {
    this.doctors = this.http.get('https://localhost:7288/api/Doctor');
    this.data = this.http.get('https://localhost:7288/api/Doctor').subscribe({
      next: (doc) => {
        this.data = doc;
      }
    });
    console.log(this.data);
    
  }

  showDoctors(){
    console.log(this.doctors);
  }

  async getDoctors(){
    const docs = this.http.get('https://localhost:7288/api/Doctor').toPromise();
    docs.then(value => {console.log(value)});
  }
}

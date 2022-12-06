import { Component } from '@angular/core';

@Component({
  selector: 'app-doctors-page',
  templateUrl: './doctors-page.component.html',
  styleUrls: ['./doctors-page.component.scss']
})
export class DoctorsPageComponent {
  doctors = [
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
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrls: ['./appointment-page.component.scss']
})
export class AppointmentPageComponent implements OnInit {
  isLogged = false;
  newAppointmentForm : FormGroup;
  userInfo = {
    name: 'John Doe',
    birthdate: '20-10-1990'
  }

  doctorList = [
    {
      name: 'John Doe',
      speciality: 'Therapist'
    },
    {
      name: 'Steven Strange',
      speciality: 'Surgeon'
    },
    {
      name: 'Bruce Banner',
      speciality: 'Physician'
    },
  ]

  serviceList = [
    {
      name: 'medical analysis',
      price: '100'
    },
    {
      name: 'bandage appliance',
      price: '50'
    },
    {
      name: 'ocular inspection',
      price: '200'
    },
    {
      name: 'surgery',
      price: '500'
    }
  ]



  constructor (private fg : FormBuilder){}


  ngOnInit(){
    this.newAppointmentForm = this.fg.group({
      name:'',
      birthdate:'',
      service:'',
      doctor: '',
      date:''
    });
    this.newAppointmentForm.valueChanges.subscribe();
  }

  makeAppointment(){
    if(this.isLogged){
      this.newAppointmentForm.value.name = this.userInfo.name;
      this.newAppointmentForm.value.birthdate = this.userInfo.birthdate;
    }
    console.log(this.newAppointmentForm.value);
  }



}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Appointment } from 'src/app/models/appointment.model';


@Component({
  selector: 'app-appointment-page',
  templateUrl: './appointment-page.component.html',
  styleUrls: ['./appointment-page.component.scss']
})
export class AppointmentPageComponent implements OnInit {

  appointmentHistory : Appointment[];

  ngOnInit(): void {
    // this.appointmentHistory = [
    //   {
    //     status : 'pending',
    //     doctor : 'Steven Strange',
    //     date : '21/01/2023',
    //     result : '',
    //     price : ''
    //   },
    //   {
    //     status : 'canceled',
    //     doctor : 'Steven Strange',
    //     date : '03/01/2023',
    //     result : '',
    //     price : ''
    //   },
    //   {
    //     status : 'complete',
    //     doctor : 'Steven Strange',
    //     date : '14/12/2022',
    //     result : 'Further investigation required',
    //     price : '120'
    //   },
    // ]
  }


}

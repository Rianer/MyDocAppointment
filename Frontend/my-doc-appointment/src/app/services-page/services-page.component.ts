import { Component, OnInit } from '@angular/core';
import { DoctorServiceService } from '../services/doctor-service.service';

@Component({
  selector: 'app-services-page',
  templateUrl: './services-page.component.html',
  styleUrls: ['./services-page.component.scss']
})
export class ServicesPageComponent implements OnInit {
  doctorData: any;
  constructor(private doctorService : DoctorServiceService){}

  ngOnInit(): void{
    this.doctorService.getData().subscribe((data) => {
      this.doctorData = data;
    });
  }

}

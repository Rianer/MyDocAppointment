import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { DoctorsServiceService } from '../doctors-service.service';
import { PatientsService } from '../patients/patients.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loggedStatus : number = 0;
  status: BehaviorSubject<number>;
  userId : string = '';

  constructor(private doctorService : DoctorsServiceService, private patientService : PatientsService){
    this.status = new BehaviorSubject(this.loggedStatus);
  }

  publishState(state : number){
    this.loggedStatus = state;
    this.status.next(this.loggedStatus);
  }

  getLoggedUser(){
    return this.patientService.getAll();
  }
}

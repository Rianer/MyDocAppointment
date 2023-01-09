import { EventEmitter, Injectable, Output } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  loggedStatus : number = 0;
  status: BehaviorSubject<number>;;

  constructor(){
    this.status = new BehaviorSubject(this.loggedStatus);
  }

  publishState(state : number){
    this.loggedStatus = state;
    this.status.next(this.loggedStatus);
  }
}

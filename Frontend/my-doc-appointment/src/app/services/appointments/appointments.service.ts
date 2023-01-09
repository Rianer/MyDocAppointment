import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Appointment, NewAppointment } from 'src/app/models/appointment.model';

@Injectable({
  providedIn: 'root'
})
export class AppointmentsService {

  private ROOT_URL = 'https://localhost:7288/api/v2/Appointment';

  constructor(private http : HttpClient) { }

  getAll(): Observable<Appointment[]>{
    return this.http.get<Appointment[]>(this.ROOT_URL);
  }

  getById(id : string) : Observable<Appointment[]>{
    const root = this.ROOT_URL + '/' + id;
    return this.http.get<Appointment[]>(root);
  }

  create(appointment: NewAppointment){
    return this.http.post(this.ROOT_URL, appointment);
  }

  deleteById(id : string){
    const root = this.ROOT_URL + '/' + id;
    return this.http.delete(root);
  }

  update(id : string, appointment : Appointment){
    const url = this.ROOT_URL + '/' + id;
    return this.http.put(url, appointment);
  }
}

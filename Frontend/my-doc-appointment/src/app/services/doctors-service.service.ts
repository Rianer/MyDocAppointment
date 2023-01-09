import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerResponse } from '../models/server-response.model';
import { Doctor, NewDoctor, UpdatedDoctor } from '../models/doctor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorsServiceService {

  private ROOT_URL = 'https://localhost:7288/api/v2/Doctor';

  constructor(private http: HttpClient) {}

  
  getAllDoctors() : Observable<Doctor[]>{
    return this.http.get<Doctor[]>(this.ROOT_URL);
  }

  getDoctorById(id : string) : Observable<Doctor>{
    const url = this.ROOT_URL + '/' + id;
    return this.http.get<Doctor>(url);
  }

  createDoctor(doctor : NewDoctor){
    return this.http.post(this.ROOT_URL, doctor);
  }

  deleteDoctor(id : string){
    const url = this.ROOT_URL + '/' + id;
    return this.http.delete(url);
  }

  updateDoctor(id : string, doctor : UpdatedDoctor){
    const url = this.ROOT_URL + '/' + id;
    return this.http.put(url, doctor);
  }
}

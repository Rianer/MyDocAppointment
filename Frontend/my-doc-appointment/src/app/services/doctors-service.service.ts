import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerResponse } from '../models/server-response.model';
import { Doctor } from '../models/doctor.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorsServiceService {

  private ROOT_URL = 'https://localhost:7288/api/Doctor';

  constructor(private http: HttpClient) {}

  
  getAllDoctors() : Observable<ServerResponse<Doctor>>{
    return this.http.get<ServerResponse<Doctor>>(this.ROOT_URL);
  }

  getDoctorById(id : string) : Observable<ServerResponse<Doctor>>{
    const url = this.ROOT_URL + '/' + id;
    return this.http.get<ServerResponse<Doctor>>(url);
  }

  createDoctor(doctor : Doctor){
    return this.http.post(this.ROOT_URL, doctor);
  }

  deleteDoctor(id : string){
    return this.http.delete(this.ROOT_URL);
  }
}

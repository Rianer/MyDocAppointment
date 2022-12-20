import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerResponse } from '../models/server-response.model';
import { Doctor } from '../models/doctor.model';

@Injectable({
  providedIn: 'root'
})
export class DoctorsServiceService {

  private ROOT_URL = 'https://localhost:7288/api/Doctor';

  constructor(private http: HttpClient) {}

  async getAllDoctors(doctors:any){
    this.http.get<ServerResponse<Doctor>>('https://localhost:7288/api/Doctor').subscribe(response => {
      console.log(response);
      return response;
    });
  }
}

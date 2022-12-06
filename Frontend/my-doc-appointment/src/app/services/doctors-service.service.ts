import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorsServiceService {

  private ROOT_URL = 'https://localhost:7288/api';

  constructor(private http: HttpClient) { 

  }

  getAllDoctors(){
    const doctors = this.http.get('https://localhost:7288/api/Doctor/Doctor');
  }
}

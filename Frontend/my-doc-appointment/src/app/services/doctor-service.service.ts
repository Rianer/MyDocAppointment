import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DoctorServiceService {

  constructor(private http: HttpClient) { }

  getData(){
    return this.http.get('https://localhost:7288/api/Doctor');
  }
}

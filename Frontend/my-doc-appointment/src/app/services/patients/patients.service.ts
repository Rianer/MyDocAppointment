import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from 'src/app/models/patient.model';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {

  private ROOT_URL = 'https://localhost:7288/api/v2/Patient';

  constructor(private http: HttpClient) {}

  getAll() : Observable<Patient[]>{
    return this.http.get<Patient[]>(this.ROOT_URL);
  }

  getById(id : string) : Observable<Patient>{
    const url = this.ROOT_URL + '/' + id;
    return this.http.get<Patient>(url);
  }
}

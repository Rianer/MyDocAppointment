import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Drug, NewDrug } from 'src/app/models/drug.model';

@Injectable({
  providedIn: 'root'
})
export class DrugsService {

  private ROOT_URL = 'https://localhost:7288/api/v2/Drug';

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<Drug[]>{
    return this.http.get<Drug[]>(this.ROOT_URL);
  }

  getById(id: string): Observable<Drug>{
    const url = this.ROOT_URL + '/' + id;
    return this.http.get<Drug>(url);
  }

  create(drug: NewDrug){
    return this.http.post(this.ROOT_URL, drug);
  }

  delete(id: string){
    const url = this.ROOT_URL + '/' + id;
    return this.http.delete(url);
  }

  update(id: string, newDrug: Drug){
    const url = this.ROOT_URL + '/' + id;
    return this.http.put(url, newDrug);
  }
}

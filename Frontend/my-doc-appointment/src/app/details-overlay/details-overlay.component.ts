import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Doctor } from '../models/doctor.model';
import { OverlayToggleService } from '../services/overlay-toggle/overlay-toggle.service';

@Component({
  selector: 'app-details-overlay',
  templateUrl: './details-overlay.component.html',
  styleUrls: ['./details-overlay.component.scss']
})
export class DetailsOverlayComponent implements OnInit{
  showOverlay: boolean = false;
  @Input() currentDoctor : Doctor;
  detailsForm : FormGroup;

  constructor(private toggleService : OverlayToggleService, private fb : FormBuilder, private http: HttpClient){}


  ngOnInit(){
    this.detailsForm = this.fb.group({
      name : '',
      surname : '',
      email : '',
      address : ''
    });
    this.detailsForm.valueChanges.subscribe();
    this.toggleService.clickedEvent.subscribe((value:number)=>{
      if(value == 1){
        this.showOverlay = true;
      }
    });
  }

  closeOverlay(e:any){
    if(e == 'force-close'){
      this.showOverlay = false;
      return
    }

    if(this.showOverlay){
      if(e.srcElement.className == 'overlay'){
        this.showOverlay = false;
      }
    }
  }

  updateDoctorInfo(){
    const values = this.detailsForm.value;
    let updatedDoctor = new Doctor(this.currentDoctor);
    for(const value in values){
      if(values[value]){
        if(value == 'name'){
          updatedDoctor.name = values[value];
        }
        else if(value == 'surname'){
          updatedDoctor.surname = values[value];
        }
        else if(value == 'email'){
          updatedDoctor.emailAddress = values[value];
        }
        else if(value == 'address'){
          updatedDoctor.homeAddress = values[value];
        }
      }
    }

    console.log(updatedDoctor);
    const link = 'https://localhost:7288/api/Doctor' + '/' + updatedDoctor.id;
    this.http.put<any>(link, updatedDoctor).subscribe(data => console.log(data));
  }

  deleteDoctor(){
    const link = 'https://localhost:7288/api/Doctor' + '/' + this.currentDoctor.id;
    this.http.delete<any>(link).subscribe(data => console.log(data));
    this.closeOverlay('force-close');
  }
}

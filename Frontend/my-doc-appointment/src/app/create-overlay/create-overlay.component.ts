import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OverlayToggleService } from '../services/overlay-toggle/overlay-toggle.service';

@Component({
  selector: 'app-create-overlay',
  templateUrl: './create-overlay.component.html',
  styleUrls: ['./create-overlay.component.scss']
})
export class CreateOverlayComponent implements OnInit{
  showOverlay: boolean = false;

  specialities = [
    'Cardiology'
  ];

  gender = [
    'Male',
    'Female'
  ];
  newDoctorForm : FormGroup;


  constructor(private toggleService : OverlayToggleService, private fg: FormBuilder, private http: HttpClient){}

  ngOnInit(){
    this.toggleService.clickedEvent.subscribe((value:number)=>{
      if(value == 2){
        this.showOverlay = true;
      }
    });

    this.newDoctorForm = this.fg.group({
      name:'',
      surname:'',
      age:'',
      emailAddress: '',
      phoneNumber:'',
      homeAddress:'',
      speciality:'',
      gender:''
    });
    this.newDoctorForm.valueChanges.subscribe();
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

  createDoctor(){
    const newDoc = this.newDoctorForm.value;
    const link = 'https://localhost:7288/api/Doctor';
    this.http.post<any>(link, newDoc).subscribe(data => console.log(data));
  }
}

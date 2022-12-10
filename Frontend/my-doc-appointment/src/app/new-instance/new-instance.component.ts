import { Component, Input, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup } from '@angular/forms';
import { Doctor } from '../models/doctor.model';

@Component({
  selector: 'new-instance',
  templateUrl: './new-instance.component.html',
  styleUrls: ['./new-instance.component.scss']
})
export class NewInstanceComponent implements OnInit {
  @Input() buttonInfo : string;
  @Input() doctor : Doctor;
  @Input() service : Doctor;
  screenVisible : boolean = false;
  @Input()insertForm : boolean = false;
  newDoctorForm : FormGroup;

  constructor (private fg: FormBuilder){}

  ngOnInit(){
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

  toggleScreen(e: any){
    if(e == 'force-toggle'){
      this.screenVisible = !this.screenVisible;
      return
    }

    if(this.screenVisible){
      if(e.srcElement.className == 'overlay'){
        this.screenVisible = !this.screenVisible;
      }
    }
    else{
      this.screenVisible = !this.screenVisible;
    }
  }

  createDoctor(){

    console.log(this.newDoctorForm);
    this.screenVisible = false;
  }
}

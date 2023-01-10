import { HttpClient, HttpResponse } from '@angular/common/http';
import {
    Component,
    OnInit,
  } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { CreateAppointment } from 'src/app/models/create-appointment.model';
import { Patient } from 'src/app/models/patient.model';
import { ServiceForm } from 'src/app/models/serviceForm.model';
import { AppointmentForm } from '../../models/appointmentForm.model';
import { Doctor } from '../../models/doctor.model';
import { DatePipe } from '@angular/common'
  
  @Component({
    selector: 'app-add-appointment',
    templateUrl: './add-appointment.component.html',
    styleUrls: ['./add-appointment.component.scss'],
  })
  export class AddAppointmentComponent implements OnInit {
    constructor(
      public dialogRef: MatDialogRef<AddAppointmentComponent>,
       private http: HttpClient, public datepipe: DatePipe
    ) {}
  
    isLogged = false;
    appointment: CreateAppointment = new CreateAppointment();
  newAppointmentForm : FormGroup<AppointmentForm>;
  patient: Patient;
  birthdate: Date;
  specialization: string = '';
  doctor: Doctor = new Doctor();

  doctors : Doctor[];

  payTypes = [
    "Card", "Cash"
  ]
  serviceList = [
    {
      name: 'Neurology',
      price: '100'
    },
    {
      name: 'Radiology',
      price: '150'
    },
    {
      name: 'Pediatrics',
      price: '200'
    },
    {
      name: 'Otorhinolaryngology',
      price: '500'
    },
    {
      name: 'Orthopedics',
      price: '500'
    },
    {
      name: 'Psychiatry',
      price: '100'
    },
    {
      name: 'Urology',
      price: '200'
    },
    {
      name: 'Dermatology',
      price: '50'
    },
    {
      name: 'Gynaecology',
      price: '250'
    },
    {
      name: 'Cardiology',
      price: '150'
    }
  ]

  ngOnInit(){
    this.setForm();
    this.setDoctors();
  }

  ngAfterViewInit(){
    this.setPatient();
  }

  ngDoCheck(){
    if(this.specialization != this.newAppointmentForm.value.service.name)
      {
        this.specialization = this.newAppointmentForm.value.service.name;
        this.setDoctorsBySpec();
      }
  }

  e: ServiceForm = new ServiceForm();
  private setForm() {
    this.newAppointmentForm = new FormGroup<AppointmentForm>({
      name: new FormControl('', Validators.required),
      doctor: new FormControl('', Validators.required),
      paymentType: new FormControl('', Validators.required),
      location: new FormControl('', Validators.required),
    date: new FormControl('', Validators.required),
    birthdate: new FormControl('', Validators.required),
    service: new FormGroup<ServiceForm>(this.e, Validators.required),
    });
  }

  async setDoctors(){
    this.http.get<Doctor[]>('https://localhost:7288/api/v1/Doctor').subscribe(response => {
        this.doctors = response;
      });
  }

  setDoctorsBySpec(){
    this.getDoctorsBySpec().subscribe({
      next: (resp) => {
        this.doctors = resp;
        this.doctor = resp[0];
      }
    });
  }
  getDoctorsBySpec(): Observable<Doctor[]>{    
      return this.http.get<Doctor[]>(`https://localhost:7288/api/v1/Doctor`);
  }

  selectDoctor(name: string, surname: string, spec: string){
    this.doctors.forEach((doc) =>
    {
      if(doc.speciality.toString().toLowerCase() === spec.toLocaleLowerCase() 
    && doc.name === name && doc.surname === surname )
      this.doctor=doc;
    }
      
    );
    this.appointment.doctorId= this.doctor.id;
  }

  async setPatient(){
    this.http.get<Patient[]>('https://localhost:7288/api/v1/Patient').subscribe(response => {
      this.patient = response[0];
      this.newAppointmentForm.value.name=this.patient.name;
    });
  }

  onDialogClose(): void {
    if (this.newAppointmentForm.dirty) {
      if (!confirm('Are you sure you want to discard your changes?')) {
        return;
      }
    }
    this.dialogRef.close();
  }

  createAppointment(): void{
    let names = this.newAppointmentForm.value.doctor.split(" ");
    this.selectDoctor(names[0], names[1], this.newAppointmentForm.value.service.name);
    let date = new Date(this.newAppointmentForm.value.date);
    let stringvalue = this.datepipe.transform(date, 'dd MMMM yyyy HH:mm');
    this.appointment.appointmentTime = stringvalue;
    this.appointment.patientId=this.patient.id;
    this.appointment.payment.amount = this.newAppointmentForm.value.service.price;
    this.appointment.specialization = this.newAppointmentForm.value.service.name;
    this.appointment.location = this.newAppointmentForm.value.location;
    if(this.newAppointmentForm.value.paymentType){
      this.appointment.payment.paymentMethod = this.newAppointmentForm.value.paymentType;
    }
    else{
    this.appointment.payment.paymentMethod= "Card"
    }

    const result = this.create(this.appointment);
    result.subscribe((resp) => {
      console.log(resp);
    });

    this.dialogRef.close();
  }
  create(appointment: CreateAppointment): Observable<HttpResponse<CreateAppointment>> {
    console.log(appointment);
    return this.http.post<CreateAppointment>('https://localhost:7288/api/v1/Appointment', appointment, {
      observe: 'response',
    });
  }
  }
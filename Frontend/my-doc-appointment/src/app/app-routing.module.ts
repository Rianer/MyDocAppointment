import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentPageComponent } from './pages/appointment-page/appointment-page.component';
import { DoctorsPageComponent } from './pages/doctors-page/doctors-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { ServicesPageComponent } from './pages/services-page/services-page.component';

const routes: Routes = [
  {path: '', component: LandingPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'services', component: ServicesPageComponent},
  {path: 'doctors', component: DoctorsPageComponent},
  {path: 'appointment', component: AppointmentPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export var Components = [LandingPageComponent, LoginPageComponent, ServicesPageComponent, DoctorsPageComponent, AppointmentPageComponent];

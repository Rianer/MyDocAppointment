import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServicesPageComponent } from './pages/services-page/services-page.component';
import { DoctorsPageComponent } from './pages/doctors-page/doctors-page.component';
import { AppointmentPageComponent } from './pages/appointment-page/appointment-page.component';
import { HttpClientModule } from '@angular/common/http';
import { NewInstanceComponent } from './new-instance/new-instance.component';
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { DetailsOverlayComponent } from './details-overlay/details-overlay.component';
import { CreateOverlayComponent } from './create-overlay/create-overlay.component';
import { DoctorsTableComponent } from './tables/doctors-table/doctors-table.component';
import { AddAppointmentComponent } from './components/add-appointment/add-appointment.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import { NgIconsModule } from '@ng-icons/core';
import { DatePipe } from '@angular/common'
import { heroUsers } from '@ng-icons/heroicons/outline';
import { AppointmentsTableComponent } from './tables/appointments-table/appointments-table.component';
import { DrugsTableComponent } from './tables/drugs-table/drugs-table.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    NavigationBarComponent,
    LoginPageComponent,
    ServicesPageComponent,
    DoctorsPageComponent,
    AppointmentPageComponent,
    NewInstanceComponent,
    AdminPageComponent,
    DetailsOverlayComponent,
    CreateOverlayComponent,
    DoctorsTableComponent,
    AppointmentsTableComponent,
    DrugsTableComponent,
    AddAppointmentComponent,
  ],
  imports: [
    MatIconModule,
    MatInputModule,
    MatDialogModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatNativeDateModule,
    NgIconsModule.withIcons({ heroUsers }),
  ],
  exports:[
    AppointmentPageComponent],
  providers: [AppointmentPageComponent, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

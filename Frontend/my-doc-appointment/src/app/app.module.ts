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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

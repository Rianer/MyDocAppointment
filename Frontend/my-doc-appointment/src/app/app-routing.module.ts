import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ServicesPageComponent } from './services-page/services-page.component';

const routes: Routes = [
  {
  path:'services',
  component:ServicesPageComponent
  },
  {
    path:'',
    component:LandingPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

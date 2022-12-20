import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { AppointmentPageComponent } from './appointment-page.component';

describe('AppointmentPageComponent', () => {
  let component: AppointmentPageComponent;
  let fixture: ComponentFixture<AppointmentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule
      ],
      declarations: [ AppointmentPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

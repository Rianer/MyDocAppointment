import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateOverlayComponent } from 'src/app/create-overlay/create-overlay.component';
import { DetailsOverlayComponent } from 'src/app/details-overlay/details-overlay.component';
import { Doctor } from 'src/app/models/doctor.model';

import { AdminPageComponent } from './admin-page.component';

describe('AdminPageComponent', () => {
  let component: AdminPageComponent;
  let fixture: ComponentFixture<AdminPageComponent>;
  
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
      ],
      declarations: [ 
        AdminPageComponent,
        DetailsOverlayComponent,
        CreateOverlayComponent,
       ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});

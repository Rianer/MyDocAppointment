import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { CreateOverlayComponent } from './create-overlay.component';

describe('CreateOverlayComponent', () => {
  let component: CreateOverlayComponent;
  let fixture: ComponentFixture<CreateOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
      ],
      declarations: [ CreateOverlayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

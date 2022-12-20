import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { DetailsOverlayComponent } from './details-overlay.component';

describe('DetailsOverlayComponent', () => {
  let component: DetailsOverlayComponent;
  let fixture: ComponentFixture<DetailsOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
      ],
      declarations: [ DetailsOverlayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

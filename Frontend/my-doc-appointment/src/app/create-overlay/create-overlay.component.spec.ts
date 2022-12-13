import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOverlayComponent } from './create-overlay.component';

describe('CreateOverlayComponent', () => {
  let component: CreateOverlayComponent;
  let fixture: ComponentFixture<CreateOverlayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
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

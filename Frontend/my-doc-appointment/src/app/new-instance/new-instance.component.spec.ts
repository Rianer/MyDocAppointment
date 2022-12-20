import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { NewInstanceComponent } from './new-instance.component';

describe('NewInstanceComponent', () => {
  let component: NewInstanceComponent;
  let fixture: ComponentFixture<NewInstanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
      ],
      declarations: [ NewInstanceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewInstanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

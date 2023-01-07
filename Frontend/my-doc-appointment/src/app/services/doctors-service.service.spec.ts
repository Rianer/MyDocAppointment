import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { DoctorsServiceService } from './doctors-service.service';

describe('DoctorsServiceService', () => {
  let service: DoctorsServiceService;

  beforeEach(() => {
    
    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
      ]
    });
    service = TestBed.inject(DoctorsServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { DesignationServiceService } from './designation-service.service';

describe('DesignationServiceService', () => {
  let service: DesignationServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DesignationServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

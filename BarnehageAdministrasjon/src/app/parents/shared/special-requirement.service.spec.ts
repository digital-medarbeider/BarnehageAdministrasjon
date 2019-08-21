import { TestBed } from '@angular/core/testing';

import { SpecialRequirementService } from './special-requirement.service';

describe('SpecialRequirementService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SpecialRequirementService = TestBed.get(SpecialRequirementService);
    expect(service).toBeTruthy();
  });
});

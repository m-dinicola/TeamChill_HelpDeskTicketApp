import { Logger } from './logger.service';
import { TestBed } from '@angular/core/testing';

describe('LoggerService', () => {
  let service: Logger;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Logger);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

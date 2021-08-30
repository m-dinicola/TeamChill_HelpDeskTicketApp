import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortTicketComponent } from './short-ticket.component';

describe('ShortTicketComponent', () => {
  let component: ShortTicketComponent;
  let fixture: ComponentFixture<ShortTicketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShortTicketComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

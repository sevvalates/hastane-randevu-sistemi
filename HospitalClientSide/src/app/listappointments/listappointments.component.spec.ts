import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListappointmentsComponent } from './listappointments.component';

describe('ListappointmentsComponent', () => {
  let component: ListappointmentsComponent;
  let fixture: ComponentFixture<ListappointmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListappointmentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListappointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

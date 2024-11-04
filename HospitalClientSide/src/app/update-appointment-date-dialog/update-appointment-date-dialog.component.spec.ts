import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAppointmentDateDialogComponent } from './update-appointment-date-dialog.component';

describe('UpdateAppointmentDateDialogComponent', () => {
  let component: UpdateAppointmentDateDialogComponent;
  let fixture: ComponentFixture<UpdateAppointmentDateDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateAppointmentDateDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateAppointmentDateDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAppointmentStatusDialogComponent } from './update-appointment-status-dialog.component';

describe('UpdateAppointmentStatusDialogComponent', () => {
  let component: UpdateAppointmentStatusDialogComponent;
  let fixture: ComponentFixture<UpdateAppointmentStatusDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateAppointmentStatusDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateAppointmentStatusDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

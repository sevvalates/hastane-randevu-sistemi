import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListappointmentsComponent } from './admin-listappointments.component';

describe('AdminListappointmentsComponent', () => {
  let component: AdminListappointmentsComponent;
  let fixture: ComponentFixture<AdminListappointmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminListappointmentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminListappointmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

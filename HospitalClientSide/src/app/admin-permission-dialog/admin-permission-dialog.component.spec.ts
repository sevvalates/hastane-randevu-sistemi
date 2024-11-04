import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPermissionDialogComponent } from './admin-permission-dialog.component';

describe('AdminPermissionDialogComponent', () => {
  let component: AdminPermissionDialogComponent;
  let fixture: ComponentFixture<AdminPermissionDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminPermissionDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdminPermissionDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

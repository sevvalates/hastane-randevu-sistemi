import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminPermissionDialogComponent } from '../admin-permission-dialog/admin-permission-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent{

  selection : string | undefined ; 
  
  constructor(
    private router: Router , 
    private dialog: MatDialog
  ) {}

  goToListAppointments(){
    this.router.navigate(['/listappointments']); 
  }
  goToSearchPatient(){
    this.router.navigate(['/searchpatient']); 
  }

  goToAddPatient(){
    this.router.navigate(['/patient']); 
  }

  goToAddDoctor(){
    this.router.navigate(['/adddoctor']); 
  }
  goToListDoctors(){
    this.router.navigate(['/listdoctors']); 
  }
  goToManagementPanel(){
    this.router.navigate(['/managementpanel']);
  }


  openDialog(): void {
      const dialogRef = this.dialog.open(AdminPermissionDialogComponent, {
        width: '350px',
        data: { selection: this.selection }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if (result === 'Yes') { 
          this.selection = result; 
          this.goToManagementPanel(); 
        }
      });
    }

}


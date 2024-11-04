import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-management-panel',
  templateUrl: './management-panel.component.html',
  styleUrl: './management-panel.component.css'
})
export class ManagementPanelComponent {


  constructor(private router: Router) {}


  goToAddDoctor(){
    this.router.navigate(['/adddoctor']); 
  }
  goToListDoctors(){
    this.router.navigate(['/listdoctors']); 
  }
  goToManagementPanel(){
    this.router.navigate(['/managementpanel']);
  }
  goToDashboard(){
    this.router.navigate(['/dashboard']);
  }
  goToAppointmentlist(){ //admin icin olan
    this.router.navigate(['/adminlistappointments']);
  }


}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientComponent } from './patient/patient.component';
import { SearchpatientComponent } from './searchpatient/searchpatient.component';
import { ListappointmentsComponent } from './listappointments/listappointments.component';
import { HomeComponent } from './home/home.component';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { ListdoctorsComponent } from './listdoctors/listdoctors.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { ManagementPanelComponent } from './management-panel/management-panel.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminListappointmentsComponent } from './admin-listappointments/admin-listappointments.component';

const routes: Routes = [
  { path: 'appointment/:socialSecurityNumber', component: AppointmentComponent },  
  { path: 'patient', component: PatientComponent },  
  { path: 'searchpatient', component: SearchpatientComponent },  
  { path: 'listappointments', component: ListappointmentsComponent },  
  { path: 'home', component: HomeComponent},
  { path: 'adddoctor', component: AddDoctorComponent},
  { path: 'listdoctors', component: ListdoctorsComponent},
  { path: 'about', component: AboutComponent},
  { path: 'contact', component: ContactComponent},
  //{ path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '', component: HomeComponent }, // Load HomeComponent by default
  { path: 'managementpanel', component: ManagementPanelComponent},
  { path: 'dashboard', component: DashboardComponent},
  { path: 'adminlistappointments', component: AdminListappointmentsComponent},
  { path: 'adminlistappointments/:status', component: AdminListappointmentsComponent } 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

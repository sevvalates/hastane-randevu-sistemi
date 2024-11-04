import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';

import { Service } from '../models/service.model';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppointmentComponent } from './appointment/appointment.component';
import { PatientComponent } from './patient/patient.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SearchpatientComponent } from './searchpatient/searchpatient.component';
import { ListappointmentsComponent } from './listappointments/listappointments.component';
import { HomeComponent } from './home/home.component';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { ListdoctorsComponent } from './listdoctors/listdoctors.component';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { UpdateAppointmentStatusDialogComponent } from './update-appointment-status-dialog/update-appointment-status-dialog.component'; // Buttonlar için
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';  
import { MatPaginatorModule } from '@angular/material/paginator';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { ManagementPanelComponent } from './management-panel/management-panel.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { AdminListappointmentsComponent } from './admin-listappointments/admin-listappointments.component';
import { UpdateAppointmentDateDialogComponent } from './update-appointment-date-dialog/update-appointment-date-dialog.component';
import { AdminPermissionDialogComponent } from './admin-permission-dialog/admin-permission-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    AppointmentComponent,
    PatientComponent,
    NavbarComponent,
    SearchpatientComponent,
    ListappointmentsComponent,
    HomeComponent,
    AddDoctorComponent,
    ListdoctorsComponent,
    UpdateAppointmentStatusDialogComponent,
    UpdateAppointmentDateDialogComponent,
    AboutComponent,
    ContactComponent,
    ManagementPanelComponent,
    DashboardComponent,
    AdminListappointmentsComponent,
    AdminPermissionDialogComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AsyncPipe , 
    FormsModule, 
    ReactiveFormsModule,
    AppRoutingModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatFormFieldModule,
    MatOptionModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatPaginatorModule ,
    CanvasJSAngularChartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

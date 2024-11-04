import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Doctor } from '../../models/doctor.model';
import { Service } from '../../models/service.model';
import { HospitalService } from '../services/hospital.service';

@Component({
  selector: 'app-update-appointment-date-dialog',
  templateUrl: './update-appointment-date-dialog.component.html',
  styleUrl: './update-appointment-date-dialog.component.css'
})
export class UpdateAppointmentDateDialogComponent implements OnInit{
 
  appointmentForm: FormGroup;

    selectedDate!: String;
    selectedHour!: number;
    selectedMinute!: number;

  hours: number[] = Array.from({ length: 24 }, (_, i) => i); // 0-23 hours
  minutes: number[] = [0, 15, 30, 45]; // 15-minute intervals
  //minDate: string;


  services$!: Observable<Service[]>; 
  Hospital: Service[] = []; 
  
  doctors$!: Observable<Doctor[]>; 
  Doctor: Doctor[] = [];

  filteredDoctors: Doctor[] = []; 
  

  constructor( private hospitalService: HospitalService,
              
    public dialogRef: MatDialogRef<UpdateAppointmentDateDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any , private fb: FormBuilder
  ) {

    this.appointmentForm = this.fb.group({
      appointmentDate: [data.date, Validators.required],
      hour: [data.hour, Validators.required],
      minute: [data.minute, Validators.required],

       doctorId: [data.doctorId],
       serviceId: [data.serviceId]
    });

    // Initialize minDate with today's date
    const now = new Date();
   // this.minDate = now.toISOString().slice(0, 10);  

    console.log("form:",this.appointmentForm);
  }
 
  ngOnInit(): void {

    this.fetchServices();
  }

  onSave(): void {

    console.log(this.appointmentForm.value); 

    if (this.appointmentForm.valid) {
      //const selectedDate = this.appointmentForm.value.appointmentDate;
      const selectedHour = this.appointmentForm.value.hour;
      const selectedMinute = this.appointmentForm.value.minute;

      const appointmentDateTime = new Date(`${this.selectedDate}T${selectedHour.toString().padStart(2, '0')}:${selectedMinute.toString().padStart(2, '0')}`);

      console.log("appointment date time :", appointmentDateTime); 

      const turkeyOffset = 3 * 60; // 3 hours in minutes
      const utcDate = new Date(appointmentDateTime.getTime() + (turkeyOffset * 60000)); // Convert to UTC+3
  
      
      const serviceId = this.appointmentForm.value.serviceId;
      const doctorId = this.appointmentForm.value.doctorId;

      //this.dialogRef.close(appointmentDateTime,serviceId,doctorId); // seçilen durumu geri döndürcek

      this.dialogRef.close({
        date: utcDate,
        serviceId: serviceId,
        doctorId: doctorId
    }); 
    }
    else{
      console.error('Form is not valid');
    }
  }

  //2024-11-08T19:15:00
  updateDOB(event: any) {
    const selectedDate = event.value;
    const localDate = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate()); 
    this.selectedDate = localDate.toLocaleDateString('en-CA'); // YYYY-MM-DD formatında alma
    console.log("date:", this.selectedDate);
  }


  public fetchServices(): void {

    this.hospitalService.getServicesRes().subscribe(
        (response) => { 
            this.Hospital = response;  // Veriyi this.service'e atıyoruz
            console.log("Servisler başarıyla getirildi", this.Hospital);
        },
        (error) => { 
            console.error('Servisleri getirirken hata oluştu:', error); 
        }
    );

    this.hospitalService.getDoctorsRes().subscribe(
      (response) => { 
          this.Doctor = response;  // Veriyi this.service'e atıyoruz
          console.log("Servisler başarıyla getirildi", this.Doctor);
      },
      (error) => { 
          console.error('Servisleri getirirken hata oluştu:', error); 
      }
    );
  }

  public fetchDoctorsByService(event: Event): void {
    const selectedValue = (event.target as HTMLSelectElement).value; // Cast to HTMLSelectElement
    const serviceId = Number(selectedValue); // Convert the value to a number
  
    if (serviceId) {
      this.filteredDoctors = this.Doctor.filter(doctor => doctor.serviceId === serviceId);
    } else {
      this.filteredDoctors = this.Doctor; // Show all doctors if no service is selected
    }
  }
}

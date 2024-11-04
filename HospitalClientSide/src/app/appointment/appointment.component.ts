import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Service } from '../../models/service.model';
import { Doctor } from '../../models/doctor.model';
import { HospitalService } from '../services/hospital.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Appointment } from '../../models/appointment.model';
import { Patient } from '../../models/patient.model';
import { CreateAppointment } from '../../models/create-appointment.model';
import { AppointmentStatus } from '../../enums/appointment-status.enum';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrl: './appointment.component.css'
})
export class AppointmentComponent implements OnInit{

  services$!: Observable<Service[]>; // Servislerin Observable hali
  Hospital: Service[] = []; // Servisleri tutmak için boş bir dizi

  corporations$!: Observable<Service[]>; 
  Corporation: Service[] = []; 
  
  doctors$!: Observable<Doctor[]>; 
  Doctor: Doctor[] = [];

  //filtreleme
  filteredDoctors: Doctor[] = []; // Seçilen servise göre filtrelenmiş doktorlar
  selectedServiceId: number | null = null; // Seçilen servis ID'si

  ssn: number | null = null;

  patient: Patient | undefined;  // Patient data to be displayed
  socialSecurityNumber!: number;
  patientId!: number; 

  
CreateAppointment: CreateAppointment = {
  id: 0,
  doctorId: 0,
  patientId: 0,
  serviceId: 0,
  appointmentDate: new Date(),
  //appointmentStatus: AppointmentStatus.Pending,
  appointmentStatus: AppointmentStatus.NoShow,
};

createAppointmentsForm = new FormGroup({
  doctorId: new FormControl<number>(0),
  serviceId: new FormControl<number>(0),
  appointmentDate: new FormControl<string | null>(null, Validators.required),
  hour: new FormControl<number | null>(null, Validators.required),
  minute: new FormControl<number | null>(null, Validators.required), 
  //appointmentStatus: new FormControl<AppointmentStatus>(AppointmentStatus.Pending)
  appointmentStatus: new FormControl<AppointmentStatus>(AppointmentStatus.NoShow)
});


  // Define hours and minutes arrays for the select dropdowns
  hours: number[] = Array.from({ length: 24 }, (_, i) => i); // 0-23 hours
  minutes: number[] = [0, 15, 30, 45]; // 15-minute intervals

minDate: string;

errorMessage: string = '';

  constructor(private hospitalService: HospitalService,
              private route: ActivatedRoute,
              private router: Router // Inject the Router
  ) {

    // Initialize minDate with today's date
    const now = new Date();
    this.minDate = now.toISOString().slice(0, 10); // Keep only the date part
  }


  ngOnInit(): void {

    // Extract 'socialSecurityNumber' from the URL
    this.socialSecurityNumber = Number(this.route.snapshot.paramMap.get('socialSecurityNumber'));

    // If socialSecurityNumber is found, fetch patient data
    if (!isNaN(this.socialSecurityNumber)) {
      this.getPatientBySSN(this.socialSecurityNumber);
      console.log("ssn:",this.socialSecurityNumber);
    } else {
      console.error('Invalid socialSecurityNumber');
    }
    
    this.fetchServices();
  }

  // Fetch patient data by socialSecurityNumber
  getPatientBySSN(socialSecurityNumber: number): void {
    this.hospitalService.getPatientRes(socialSecurityNumber).subscribe(
      (response: Patient) => {
        this.patient = response;
        
        this.patientId = this.patient.id;

        console.log('Patient data fetched successfully', this.patientId);
      },
      (error) => {
        console.error('Error fetching patient data:', error);
      }
    );
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

    this.hospitalService.getCorporationsRes().subscribe(
      (response) => { 
          this.Corporation = response;  // Veriyi this.service'e atıyoruz
          console.log("Servisler başarıyla getirildi", this.Corporation);
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


  onFormSubmit(){

    if (this.createAppointmentsForm.invalid) {
      console.error('Form is invalid due to invalid minute selection');
      return; // Form geçersizse işlemi durdur
    }
    this.CreateAppointment.doctorId = this.createAppointmentsForm.value.doctorId ?? 0;
    this.CreateAppointment.patientId = this.patientId;
    this.CreateAppointment.serviceId = this.createAppointmentsForm.value.serviceId ?? 0;

    const formValue = this.createAppointmentsForm.value;

    // minute değerini iki basamaklı hale getir
    const minuteFormatted = String(formValue.minute).padStart(2, '0');

    // Date nesnesi oluştururken saat ve dakika değerlerini kontrol et
    const hourFormatted = String(formValue.hour).padStart(2, '0');

    console.log("min: ",minuteFormatted,"hour",hourFormatted);

    //const selectedDate = new Date(`${formValue.appointmentDate}T${formValue.hour}:${formValue.minute}:00`);
    const selectedDateString = `${formValue.appointmentDate}T${hourFormatted}:${minuteFormatted}:00`;
    console.log('Selected Date String:', selectedDateString); // Hataları görmek için kontrol edin
  
    const selectedDate = new Date(selectedDateString);

    console.log('Selected Date:', selectedDate);

    const turkeyOffset = 3 * 60; // 3 hours in minutes
    const utcDate = new Date(selectedDate.getTime() + (turkeyOffset * 60000)); // Convert to UTC+3

    this.CreateAppointment.appointmentDate = utcDate;

    this.hospitalService.postAppointmentReq(this.CreateAppointment).subscribe(
      (response) => {
        console.log('Appointment successfully added', response);
        // Navigate to the 'listappointments' page after successful form submission
        this.router.navigate(['/listappointments']);
      },
      (error) => {
        debugger
        if(error.status === 409){
          this.errorMessage = error.error.message; 
          console.log('Error:', error.error); // 'SSN already exists.'
        }
        else{
          console.error('Error adding Appointment:', error);
        }
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

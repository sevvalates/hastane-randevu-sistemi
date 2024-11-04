import { Component } from '@angular/core';
import { Gender } from '../../enums/gender.enum';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Service } from '../../models/service.model';
import { Observable } from 'rxjs';
import { Doctor } from '../../models/doctor.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { HospitalService } from '../services/hospital.service';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrl: './add-doctor.component.css'
})
export class AddDoctorComponent {


    // Enum to string mapping
    genderMap: { [key : number]: string } = {
      [Gender.Female]: 'Kadın',
      [Gender.Male]: 'Erkek',
      [Gender.Other]: 'Belirtmek istemiyor',
    };

    doctorForm = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(50),
      ]),
      surname: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(50),
      ]),
      socialSecurityNumber: new FormControl<number>(0, [
        Validators.required,
        Validators.pattern('^[0-9]{11}$'), // 11 haneli bir rakam kontrolü
      ]),
      gender: new FormControl<Gender>(Gender.Other, [Validators.required]),
      serviceId: new FormControl<number>(0, Validators.required),
    });

    services$!: Observable<Service[]>; // Servislerin Observable hali
    Hospital: Service[] = []; // Servisleri tutmak için boş bir dizi

    
  Doctor: Doctor = {
    id: 0,
    name: '',
    surname: '',
    socialSecurityNumber: 0,
    gender: Gender.Other,
    serviceId: 0,
  };

  Gender = Gender;
  errorMessage: string = '';

  
  constructor(
    private hospitalService: HospitalService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.fetchServices(); // Bileşen yüklendiğinde servisleri getir
  }

  public fetchServices(): void {
    this.hospitalService.getServicesRes().subscribe(
      (response) => {
        this.Hospital = response; // Veriyi this.service'e atıyoruz
        console.log('Servisler başarıyla getirildi', this.Hospital);
      },
      (error) => {
        console.error('Servisleri getirirken hata oluştu:', error);
      }
    );
  }

  onFormSubmit() {
    console.log(this.doctorForm.value);

    this.Doctor.name = this.doctorForm.value.name || '';
    this.Doctor.surname = this.doctorForm.value.surname || '';

    console.log("BBBB",this.doctorForm.value.gender,Number(this.doctorForm.value.gender));

    this.Doctor.gender = Number(this.doctorForm.value.gender) || Gender.Other;
    this.Doctor.socialSecurityNumber = this.doctorForm.value.socialSecurityNumber || 0;
    this.Doctor.serviceId = this.doctorForm.value.serviceId || 1;

    this.hospitalService.postDoctorReq(this.Doctor).subscribe(
      (response) => {
        console.log('Doctor successfully added', response);
        this.errorMessage = '';
        this.router.navigate(['/listdoctors']);
      },
      (error) => {
        if(error.status === 409){
          this.errorMessage = error.error.message; 
          console.log('Error:', error.error.message); // 'SSN already exists.'
        }
        else{
          this.errorMessage = 'An unexpected error occurred.';
          console.error('Error adding patient:', error);
        }
      }
    );
  }


  onServiceChange(event: any){
    const selectedServiceId = event.target.value; 
    this.doctorForm.patchValue({ serviceId: selectedServiceId });
    }

}

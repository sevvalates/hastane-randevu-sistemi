import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Service } from '../../models/service.model';
import { Doctor } from '../../models/doctor.model';
import { Patient } from '../../models/patient.model';
import { HospitalService } from '../services/hospital.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; // Router'ı import et
import { Gender } from '../../enums/gender.enum';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrl: './patient.component.css',
})
export class PatientComponent {
  servicesForm = new FormGroup({
    name: new FormControl<String>(''),
  });

    // Make the Gender enum accessible in the template
    Gender = Gender;

  // Enum to string mapping
  genderMap: { [key : number]: string } = {
    [Gender.Female]: 'Kadın',
    [Gender.Male]: 'Erkek',
    [Gender.Other]: 'Belirtmek istemiyor',
  };
  patientsForm = new FormGroup({
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
    gender: new FormControl<Gender>(Gender.Other, [Validators.required]),
    socialSecurityNumber: new FormControl<number>(0, [
      Validators.required,
      Validators.pattern('^[0-9]{11}$'), // 11 haneli bir rakam kontrolü
    ]),
    corporationId: new FormControl<number>(0, Validators.required),
  });
 

  services$!: Observable<Service[]>; // Servislerin Observable hali
  Hospital: Service[] = []; // Servisleri tutmak için boş bir dizi

  corporations$!: Observable<Service[]>; 
  Corporation: Service[] = []; 

  doctors$!: Observable<Doctor[]>; 
  Doctor: Doctor[] = []; 

  Patient: Patient = {
    id: 0,
    name: '',
    surname: '',
    gender: Gender.Other,
    socialSecurityNumber: 0,
    corporationId: 0,
  };
  
  errorMessage: string = '';

  constructor(
    private hospitalService: HospitalService,
    private router: Router
  ) {}

  ngOnInit() {
    this.fetchServices(); // Bileşen yüklendiğinde servisleri getir
  }

  public fetchServices(): void {

    this.hospitalService.getCorporationsRes().subscribe(
      (response) => {
        this.Corporation = response; // Veriyi this.service'e atıyoruz
        console.log('Servisler başarıyla getirildi', this.Corporation);
      },
      (error) => {
        console.error('Servisleri getirirken hata oluştu:', error);
      }
    );
  }

  onFormSubmit() {
    console.log(this.patientsForm.value);

    this.Patient.name = this.patientsForm.value.name || '';
    this.Patient.surname = this.patientsForm.value.surname || '';
    //this.Patient.gender = this.patientsForm.value.gender || Gender.Other;

    console.log("BBBB",this.patientsForm.value.gender,Number(this.patientsForm.value.gender));

    this.Patient.gender = Number(this.patientsForm.value.gender) || Gender.Female;
    this.Patient.socialSecurityNumber = this.patientsForm.value.socialSecurityNumber || 0;
    this.Patient.corporationId = this.patientsForm.value.corporationId || 1;

    this.hospitalService.postPatientReq(this.Patient).subscribe(
      (response) => {
        debugger
        console.log('Patient successfully added', response);
        this.errorMessage = '';
        this.router.navigate(['/searchpatient']);
      },
      (error) => {
        debugger 
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

  onCorporationChange(event: any) {
    const selectedCorpId = event.target.value; // Get selected corporation ID
    this.patientsForm.patchValue({ corporationId: selectedCorpId }); // Set the corporationId in the form
  }
}

import { Component } from '@angular/core';
import { HospitalService } from '../services/hospital.service';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { Patient } from '../../models/patient.model';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { Gender } from '../../enums/gender.enum';
import { Service } from '../../models/service.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-searchpatient',
  templateUrl: './searchpatient.component.html',
  styleUrl: './searchpatient.component.css'
})
export class SearchpatientComponent {

    genderMap: { [key : number]: string } = {
    [Gender.Female]: 'Kadın',
    [Gender.Male]: 'Erkek',
    [Gender.Other]: 'Belirtmek istemiyor',
    };

  // Corporation name mapping
  corporationMap: { [key: number]: string } = {};

  patients$!: Observable<Patient[]>; // Servislerin Observable hali
  Patient: Patient[] = []; // Servisleri tutmak için boş bir dizi
  filteredPatients: Patient[] = []; // Filtrelenmiş hastalar

  corporations$!: Observable<Service[]>; 
  Corporation: Service[] = []; 

  paginatedPatients: Patient[] = [];
  pageSize: number = 5; // Sayfa başına gösterilecek doktor sayısı
  pageIndex: number = 0; // Geçerli sayfa indeksi

  selectedOption: string = 'Sırala';

  constructor(private hospitalService: HospitalService, 
              private router: Router
  ) {
    //this.fetchServices();
  }

  ngOnInit() {
    this.fetchServices(); // Bileşen yüklendiğinde servisleri getir
  }

  public fetchServices(): void {
      this.hospitalService.getPatientsRes().subscribe(
          (response) => { 
              this.Patient = response;  // Veriyi this.service'e atıyoruz
              this.filteredPatients =  this.Patient; // Başlangıçta filtrelenmiş liste aynı olur
              this.updatePaginatedPatients();
              console.log("Patients başarıyla getirildi", this.Patient);
          },
          (error) => { 
              console.error('Patients getirirken hata oluştu:', error); 
          }
      );

      this.hospitalService.getCorporationsRes().subscribe(
        (response) => { 
            this.Corporation = response;  // Veriyi this.service'e atıyoruz
            console.log("corporations başarıyla getirildi", this.Corporation);

            // Create a map for corporationId to corporationName
            this.Corporation.forEach(corporation => {
              this.corporationMap[corporation.id] = corporation.name;
            });
        },
        (error) => { 
            console.error('corporations getirirken hata oluştu:', error); 
        }
      );
      
  }

    // Arama kutusundaki girişe göre hastaları filtrele
    filterPatients(event: Event) {
      const searchValue = (event.target as HTMLInputElement).value.toLowerCase();
      this.filteredPatients = this.Patient ? this.Patient.filter(patient =>
        (patient.name && patient.name.toLowerCase().includes(searchValue)) ||
        (patient.surname && patient.surname.toLowerCase().includes(searchValue)) ||
        (patient.socialSecurityNumber && patient.socialSecurityNumber.toString().includes(searchValue))
      ) : []; // Eğer Patient tanımlı değilse boş dizi döner

      this.updatePaginatedPatients(); // Sayfalamayı güncelle
    }

    goToAppointment(Ssn: number) {
      console.log(this.filterPatients);
      console.log(this.Patient);
      console.log('Navigating to detail with SSN:', Ssn);
      
      if (Ssn) {
        this.router.navigate(['/appointment', Ssn]); // 'hasta-detay' yönlendireceğin sayfanın yolu
        console.log('Navigating to detail with SSN:', Ssn);
      }else {
        console.error('SSN is undefined');
      }
    }

    goToAddPatient() {
      console.log('Navigating to add patient:');
      this.router.navigate(['/patient']); // 'hasta-detay' yönlendireceğin sayfanın yolu
    }

    updatePaginatedPatients() {
      const startIndex = this.pageIndex * this.pageSize;
      this.paginatedPatients = this.filteredPatients.slice(startIndex, startIndex + this.pageSize);
    }
  
    onPageChange(event: PageEvent) {
      this.pageIndex = event.pageIndex; 
      this.pageSize = event.pageSize; 
      this.updatePaginatedPatients(); 
    }


    ArrangeByName() {
      this.selectedOption="İsme Göre";

      this.filteredPatients.sort((a: Patient, b: Patient) => {
        return a.name.localeCompare(b.name);
      });

      this.updatePaginatedPatients();
    }

    ArrangeByCorporation() {
      this.selectedOption="Kuruma Göre";

      this.filteredPatients.sort((a: Patient, b: Patient) => {
        return this.corporationMap[a.corporationId].localeCompare(this.corporationMap[b.corporationId]);
      });

      this.updatePaginatedPatients();
    }

    ArrangeBySsn() {
      this.selectedOption="Kimlik Numarasına Göre";

      this.filteredPatients.sort((a: Patient, b: Patient) => {
        return a.socialSecurityNumber - b.socialSecurityNumber; 
      });

      this.updatePaginatedPatients();
    }
       
}

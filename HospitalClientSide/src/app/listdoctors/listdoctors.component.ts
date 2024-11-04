import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Gender } from '../../enums/gender.enum';
import { Doctor } from '../../models/doctor.model';
import { HospitalService } from '../services/hospital.service';
import { Service } from '../../models/service.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-listdoctors',
  templateUrl: './listdoctors.component.html',
  styleUrl: './listdoctors.component.css'
})
export class ListdoctorsComponent {

  // service name mapping
  serviceMap: { [key: number]: string } = {};

  genderMap: { [key : number]: string } = {
    [Gender.Female]: 'Kadın',
    [Gender.Male]: 'Erkek',
    [Gender.Other]: 'Belirtmek istemiyor',
  };

  doctors$!: Observable<Doctor[]>;
  Doctor: Doctor[] = [];
  filteredDoctors: Doctor[] = []; // Filtrelenmiş hastalar


  services$!: Observable<Service[]>;
  Service: Service[] = [];

  //sayfalama kısmı için
  paginatedDoctors: Doctor[] = [];
  pageSize: number = 10; // Sayfa başına gösterilecek doktor sayısı
  pageIndex: number = 0; // Geçerli sayfa indeksi

  selectedOption : string= "Sırala";

  constructor(
    private hospitalService: HospitalService,
  ) {}

  ngOnInit() {
    this.fetchServices(); // Bileşen yüklendiğinde servisleri getir
  }

  public fetchServices(): void {
    this.hospitalService.getDoctorsRes().subscribe(
      (response) => {
        this.Doctor = response; // Veriyi this.service'e atıyoruz
        console.log('Doctors başarıyla getirildi', this.Doctor);
        //this.router.navigate(['/listdoctors']); //30.10.24
        this.filteredDoctors= response; //BURADA KALDI 
        this.updatePaginatedDoctors(); // Sayfalanmış doktorları güncelle
      },
      (error) => {
        console.error('Doctors getirirken hata oluştu:', error);
      }
    );

    this.hospitalService.getServicesRes().subscribe(
      (response) => {
        this.Service = response; // Veriyi this.service'e atıyoruz
        console.log('Services başarıyla getirildi', this.Service);

        // Create a map for corporationId to corporationName
        this.Service.forEach(service => {
          this.serviceMap[service.id] = service.name;
        });
      },
      (error) => {
        console.error('Services getirirken hata oluştu:', error);
      }
    );
  }

    // Sayfalama için doktorları güncelleme
    updatePaginatedDoctors() {
      const startIndex = this.pageIndex * this.pageSize;
      //this.paginatedDoctors = this.Doctor.slice(startIndex, startIndex + this.pageSize);
      this.paginatedDoctors = this.filteredDoctors.slice(startIndex, startIndex + this.pageSize);
    }
  
    onPageChange(event: PageEvent) {
      this.pageIndex = event.pageIndex; //geçerli sayfanın indeksi
      this.pageSize = event.pageSize; // her sayfada gösterilecek olan öğe sayısını 
      this.updatePaginatedDoctors(); // Sayfalamayı güncelle
    }

    ArrangeByName() {
      this.selectedOption="İsme Göre";
/*
      this.Doctor.sort((a: Doctor, b: Doctor) => {
        return a.name.localeCompare(b.name);
      });
*/

      this.filteredDoctors.sort((a: Doctor, b: Doctor) => {
        return a.name.localeCompare(b.name);
      });

      this.updatePaginatedDoctors();
    }

    ArrangeByService() {
      this.selectedOption="Servise Göre";
      /*
      this.Doctor.sort((a: Doctor, b: Doctor) => {
        return this.serviceMap[a.serviceId].localeCompare(this.serviceMap[b.serviceId]);
      });
      */
      this.filteredDoctors.sort((a: Doctor, b: Doctor) => {
        return this.serviceMap[a.serviceId].localeCompare(this.serviceMap[b.serviceId]);
      });

      this.updatePaginatedDoctors();
    }

    ArrangeBySsn() {
      this.selectedOption="Kimlik Numarasına Göre";
/*
      this.Doctor.sort((a: Doctor, b: Doctor) => {
        return a.socialSecurityNumber - b.socialSecurityNumber; 
      });
*/
      this.filteredDoctors.sort((a: Doctor, b: Doctor) => {
        return a.socialSecurityNumber - b.socialSecurityNumber; 
      });
      
      this.updatePaginatedDoctors();
    }
    

    filterDoctors(event: Event) {
      const searchValue = (event.target as HTMLInputElement).value.toLowerCase();
      console.log("filtrd",searchValue);

      this.filteredDoctors = this.Doctor ? this.Doctor.filter(doctor =>
        (doctor.name && doctor.name.toLowerCase().includes(searchValue)) ||
        (doctor.surname && doctor.surname.toLowerCase().includes(searchValue)) 
        //|| (doctor.socialSecurityNumber && doctor.socialSecurityNumber.toString().includes(searchValue)) || // SSN kontrolü
        //(doctor.serviceId && doctor.serviceId.toString().includes(searchValue)) // Corporation ID kontrolü
      ) : []; 
      
      this.updatePaginatedDoctors(); // Sayfalamayı güncelle
      
      console.log("filtrd docs",this.paginatedDoctors);
    }
}



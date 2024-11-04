import { Component } from '@angular/core';
import { Appointment } from '../../models/appointment.model';
import { Observable } from 'rxjs';
import { HospitalService } from '../services/hospital.service';
import { AppointmentStatus } from '../../enums/appointment-status.enum';
import { CreateAppointment } from '../../models/create-appointment.model';
import { Gender } from '../../enums/gender.enum';
import { MatDialog } from '@angular/material/dialog';
import { UpdateAppointmentStatusDialogComponent } from '../update-appointment-status-dialog/update-appointment-status-dialog.component';
import { PageEvent } from '@angular/material/paginator';
import { UpdateAppointmentDateDialogComponent } from '../update-appointment-date-dialog/update-appointment-date-dialog.component';

@Component({
  selector: 'app-listappointments',
  templateUrl: './listappointments.component.html',
  styleUrl: './listappointments.component.css',
})
export class ListappointmentsComponent {

  isUpdating: boolean = false; // Flag to track if an update is in progress

  CreateAppointment: CreateAppointment = {
    id: 0,
    doctorId: 0,
    patientId: 0,
    serviceId: 0,
    appointmentDate: new Date(),
    //appointmentStatus: AppointmentStatus.Pending,
    appointmentStatus: AppointmentStatus.NoShow,
  };

  // Enum to string mapping
  appointmentStatusMap: { [key: number]: string } = {
    [AppointmentStatus.Pending]: 'Beklemede',
    [AppointmentStatus.Completed]: 'Taburcu',
    [AppointmentStatus.Cancelled]: 'İptal',
    [AppointmentStatus.NoShow]: 'Gelmedi',
  };

  genderMap: { [key : number]: string } = {
    [Gender.Female]: 'Kadın',
    [Gender.Male]: 'Erkek',
    [Gender.Other]: 'Belirtmek istemiyor',
  };

  // Expose the AppointmentStatus enum for use in the template
  AppointmentStatus = AppointmentStatus;

  appointments$!: Observable<Appointment[]>;
  Appointment: Appointment[] = [];

  //sayfalama kısmı için
  paginatedAppointments: Appointment[] = [];
  pageSize: number = 5; // Sayfa başına gösterilecek doktor sayısı
  pageIndex: number = 0; // Geçerli sayfa indeksi
  
  selectedOption: string = 'Sırala';

  filteredAppointments: Appointment[] = [];

  constructor(
    private hospitalService: HospitalService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.fetchServices(); // Bileşen yüklendiğinde servisleri getir
  }

  public fetchServices(): void {
    this.hospitalService.getAppointmentsRes().subscribe(
      (response) => {
         //sadece statüsü "beklemede" ve "gelmedi" olan randevuları alalım
        this.Appointment = response.filter(
          appointment => appointment.appointmentStatus === 0 || appointment.appointmentStatus === 3
        );

        this.filteredAppointments = this.Appointment; 

        this.ArrangeByDate();
        console.log('Appointments başarıyla getirildi', this.Appointment);

        //this.router.navigate(['/listappointments']);
      },
      (error) => {
        console.error('Appointments getirirken hata oluştu:', error);
      }
    );
  }

  openStatusDialog(appointment: Appointment): void {
    const dialogRef = this.dialog.open(UpdateAppointmentStatusDialogComponent, {
      width: '300px',
      data: { status: appointment.appointmentStatus } 
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Seçilen durumu kaydet
        this.changeStatus(appointment, result);
      }
    });
  }
  changeStatus(appointment: Appointment, status: AppointmentStatus): void {
    
    appointment.appointmentStatus = status; // Update the appointment's status
    console.log(`Status changed to: ${this.appointmentStatusMap[status]}`);

    console.log(`appoinment statute appointment: `,appointment.appointmentDate);

    this.hospitalService.updateAppointment(appointment).subscribe(
        (response) => {
          console.log('Appointment status updated successfully', response);
        },
        (error) => {
          console.error('Error updating appointment status:', error);
          console.log("error update status",appointment)
        },
      );
      
  }

openDateDialog(appointment: Appointment): void {

  const dialogRef = this.dialog.open(UpdateAppointmentDateDialogComponent, {
    width: '1000px',
    data: {date: appointment.appointmentDate,
           doctorId: appointment.doctorId,
           serviceId: appointment.serviceId
          }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      //this.changeDate(appointment, result);
      this.changeDate(appointment, result.date, result.doctorId, result.serviceId);
    }
  });

}


  changeDate(appointment: Appointment , AppointmentDate: Date ,DoctorId: number , ServiceId: number): void {

      if(AppointmentDate != null){
        console.log(  "dateeeee", AppointmentDate);
        appointment.appointmentDate = AppointmentDate;
      }
      
      if(DoctorId != null){
        console.log(  "dr ıddd", AppointmentDate);
        appointment.doctorId = DoctorId;
      }
      
      if(ServiceId != null){
        appointment.serviceId = ServiceId;
      }
      console.log("appointment son hal",appointment);
  
      this.hospitalService.updateAppointment(appointment).subscribe(
          (response) => {
            console.log('Appointment date updated successfully', response);
          },
          (error) => {
            console.error('Error updating appointment date:', error);
          },
        );

        //this.fetchServices();
        window.location.reload(); // Sayfayı tamamen yeniler
    }
  
    // Sayfalama için doktorları güncelleme
    updatePaginatedAppointments() {
      const startIndex = this.pageIndex * this.pageSize;
      this.paginatedAppointments = this.filteredAppointments.slice(startIndex, startIndex + this.pageSize);
    }
  
    onPageChange(event: PageEvent) {
      this.pageIndex = event.pageIndex; //geçerli sayfanın indeksi
      this.pageSize = event.pageSize; // her sayfada gösterilecek olan öğe sayısını 
      this.updatePaginatedAppointments(); // Sayfalamayı güncelle
    }

    ArrangeByName() {
      this.selectedOption="İsme Göre";

      this.filteredAppointments.sort((a: Appointment, b: Appointment) => {
        return a.patientName.localeCompare(b.patientName);
      });

      this.updatePaginatedAppointments();
    }

    ArrangeByDate() {
      this.selectedOption="Tarihe Göre";

      this.filteredAppointments.sort((a: Appointment, b: Appointment) => {
        const dateA = new Date(a.appointmentDate); 
        const dateB = new Date(b.appointmentDate); 
        return dateA.getTime() - dateB.getTime(); 
      });

      this.updatePaginatedAppointments()
    }

    ArrangeByStatus() {
      this.selectedOption="Randevu Durumuna Göre";

      this.filteredAppointments.sort((a: Appointment, b: Appointment) => {
        return a.appointmentStatus - b.appointmentStatus; 
      });

      this.updatePaginatedAppointments();
    }


    filterAppointments(event: Event) {
      const searchValue = (event.target as HTMLInputElement).value.toLowerCase();
      console.log("filtrd",searchValue);

      this.filteredAppointments = this.Appointment ? this.Appointment.filter(appointment =>
        (appointment.patientName && appointment.patientName.toLowerCase().includes(searchValue)) ||
        (appointment.patientSurname && appointment.patientSurname.toLowerCase().includes(searchValue))
      ) : []; 
      
      this.updatePaginatedAppointments(); // Sayfalamayı güncelle
      
      console.log("filtrd appointments",this.paginatedAppointments);
    }
}

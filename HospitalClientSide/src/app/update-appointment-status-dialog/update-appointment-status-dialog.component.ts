import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AppointmentStatus } from '../../enums/appointment-status.enum';

@Component({
  selector: 'app-update-appointment-status-dialog',
  templateUrl: './update-appointment-status-dialog.component.html',
  styleUrl: './update-appointment-status-dialog.component.css'
})
export class UpdateAppointmentStatusDialogComponent implements OnInit{

  
  appointmentStatusMap: { [key: number]: string } = {
    [AppointmentStatus.Pending]: 'Beklemede',
    [AppointmentStatus.Completed]: 'Tamamlandı',
    [AppointmentStatus.Cancelled]: 'İptal Edildi',
    [AppointmentStatus.NoShow]: 'Gelmedi',
  };

    //selectedStatus: AppointmentStatus = AppointmentStatus.Pending;
    selectedStatus: AppointmentStatus = AppointmentStatus.NoShow;

    // Enum'a erişim için
    AppointmentStatus= AppointmentStatus;

  constructor(
    public dialogRef: MatDialogRef<UpdateAppointmentStatusDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.selectedStatus = data.status; //başlangıçta mevcut durumu almak için
  }
  ngOnInit(){}

  onSave(): void {
    this.dialogRef.close(this.selectedStatus); //seçilen durumu geri döndür
  }
}

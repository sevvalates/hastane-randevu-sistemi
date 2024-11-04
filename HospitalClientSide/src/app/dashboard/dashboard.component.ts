import { Component } from '@angular/core';
import { HospitalService } from '../services/hospital.service';
import { Appointment } from '../../models/appointment.model';
import { AppointmentstatusStatistic } from '../../models/appointmentstatus-statistic.model';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  Appointment: Appointment[] = [];

  //StatusCount: number[][][][] = [];
  StatusCount: AppointmentstatusStatistic[] = [];
  chartOptions: any;
  current_month: number;

  //
  // beklemede iptal taburcu gelmedi
  // aylık olarak oran göster 
  // array tutsak 4boyutlu 12 ay için arr[][][][] ya da 4 tane ayrı array yine 12 ay için  


  constructor(private hospitalService: HospitalService,private dialog: MatDialog , private router: Router) {
    const currentDate = new Date();
    this.current_month = currentDate.getMonth();

    for (let i = 0; i < 12; i++) {
      this.StatusCount[i] = {
        Pending: 0,
        Completed: 0,
        Cancelled: 0,
        NoShow: 0
      };
    }
  }


    ngOnInit() {
      this.fetchServices(); // Fetch the appointments when the component is initialized
      this.countData();
      this.initializeChartOptions(); // Initialize chart options here
    }
  
    private initializeChartOptions(): void {
      this.chartOptions = {
        animationEnabled: true,
        theme: "light2",
        exportEnabled: true,
        title: {
          text: "Bu Ayın Randevu Durumu İstatistiği"
        },
        data: [{
          type: "pie",
          indexLabel: "{name}: {y}%",
          dataPoints: [
            { name: "Beklemede", y: this.StatusCount[this.current_month]?.Pending || 0 },
            { name: "Taburcu", y: this.StatusCount[this.current_month]?.Completed || 0 },
            { name: "İptal", y: this.StatusCount[this.current_month]?.Cancelled || 0 },
            { name: "Gelmedi", y: this.StatusCount[this.current_month]?.NoShow || 0 },
          ],
          click: (event: any) => this.onChartItemClick(event)
        }]
      };
    }
  
    public fetchServices(): void {
      this.hospitalService.getAppointmentsRes().subscribe(
        (response) => {
          this.Appointment = response;
          console.log('Appointments başarıyla getirildi', this.Appointment)
          this.countData(); 
        },
        (error) => {
          console.error('Appointments getirirken hata oluştu:', error);
        }
      );
    }

countData() {
  for (let i = 0; i < this.Appointment.length; i++) {

    let appointmentDate = new Date(this.Appointment[i].appointmentDate);
    if (!isNaN(appointmentDate.getTime())) {
      let month = appointmentDate.getMonth();

      if (month === this.current_month) {
        switch (this.Appointment[i].appointmentStatus) {
          case 0:
            this.StatusCount[month].Pending++;
            break;
          case 1:
            this.StatusCount[month].Completed++;
            break;
          case 2:
            this.StatusCount[month].Cancelled++;
            break;
          case 3:
            this.StatusCount[month].NoShow++;
            break;
        }
      }
    } else {
      console.error('Invalid appointment date:', this.Appointment[i].appointmentDate);
    }
  }

  this.initializeChartOptions();
}


onChartItemClick(event: any): void {
  //console.log(event.dataPoint.name);
  const status = event.dataPoint.name;
  this.router.navigate(['/adminlistappointments', status]);}
}

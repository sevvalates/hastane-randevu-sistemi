import { inject, Injectable } from '@angular/core';
import { Service } from '../../models/service.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Doctor } from '../../models/doctor.model';
import { Patient } from '../../models/patient.model';
import { CreateAppointment } from '../../models/create-appointment.model';
import { Appointment } from '../../models/appointment.model';


const BASEURL='http://localhost:5000/api/';


@Injectable({
  providedIn: 'root'
})

export class HospitalService {

  private http = inject(HttpClient)
  constructor() { }


  getServicesRes() {
    console.log("test");

    //debugger
    return this.http.get<Service[]>(`${BASEURL}Services`);
    console.log("test");
  }

  getCorporationsRes() {
    console.log("test");

    //debugger
    return this.http.get<Service[]>(`${BASEURL}Corporations`);
    console.log("test");
  }

  getDoctorsRes() {
    console.log("test");
    //debugger
    return this.http.get<Doctor[]>(`${BASEURL}Doctors`);
    console.log("test");
    } 

    postPatientReq(Patient: Patient){
      //debugger
      console.log("Patient: ", Patient);
      console.log("PostPatienttest");
      return this.http.post<Patient>(`${BASEURL}Patients`,Patient);
    }

    getPatientsRes(){
      //debugger
      console.log("PatientRestest");
      return this.http.get<Patient[]>(`${BASEURL}Patients`);
    }

    getPatientRes(socialSecurityNumber: number): Observable<Patient> {
      //debugger
      console.log("PatientRestest");
      return this.http.get<Patient>(`${BASEURL}Patients/${socialSecurityNumber}`);
    }

    postAppointmentReq(CreateAppointment : CreateAppointment){
      console.log("postAppointmentReq test");
      return this.http.post<CreateAppointment>(`${BASEURL}Appointments`,CreateAppointment);
    }

    // Doktorları seçilen servis ID'sine göre filtreleyen fonksiyon
    filterDoctorsByService(doctors: Doctor[], serviceId: number): Doctor[] {
      return doctors.filter(doctor => doctor.serviceId === serviceId);
    }
 

    getAppointmentsRes() {
      return this.http.get<Appointment[]>(`${BASEURL}Appointments`);
    }

    getAppointmentRes(id : number): Observable<CreateAppointment> {
      //debugger
      console.log("id",id);
      return this.http.get<CreateAppointment>(`${BASEURL}Appointments/${id}`);
    }

    updateAppointment(Appointment: Appointment): Observable<Appointment> {
      //debugger
      console.log("sent appointment", Appointment);
      return this.http.put<Appointment>(`${BASEURL}Appointments`, Appointment);
    }

    postDoctorReq(Doctor: Doctor) {
      console.log("postDoctorReq test");
      return this.http.post<Doctor>(`${BASEURL}Doctors`,Doctor);
    }
}

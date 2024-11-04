/*
export interface Appointment {            
    doctorId: number;     
    patientId: number;       
    serviceId: number;     
    appointmentDate: Date;   
    appointmentStatus: string;
}*/

import { AppointmentStatus } from "../enums/appointment-status.enum";
import { Gender } from "../enums/gender.enum";
/*
export interface Appointment {
    patientName: string;
    patientSurname: string;
    doctorName: string;
    doctorSurname: string;
    serviceName: string;
    appointmentDate: Date;   
    appointmentStatus: AppointmentStatus;
}
*/


export interface Appointment {
    id: number;

    patientName: string;
    patientSurname: string;

    patientGender: Gender;
    
    doctorName: string;
    doctorSurname: string;
    serviceName: string;
    
    doctorId: number;
    serviceId: number;

    appointmentDate: Date;   
    appointmentStatus: AppointmentStatus;
}





import { AppointmentStatus } from "../enums/appointment-status.enum";

export interface CreateAppointment {     
    id: number;       
    doctorId: number;     
    patientId: number;       
    serviceId: number;     
    appointmentDate: Date;   
    appointmentStatus: AppointmentStatus;
}
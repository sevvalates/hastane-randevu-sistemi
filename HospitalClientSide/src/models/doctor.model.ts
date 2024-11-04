import { Gender } from "../enums/gender.enum";

export interface Doctor {
   id: number;
   name: string;
   surname: string;
   socialSecurityNumber: number;
   gender: Gender;
   serviceId: number;
}
  
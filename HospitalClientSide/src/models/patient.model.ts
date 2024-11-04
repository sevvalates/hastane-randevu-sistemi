import { Gender } from "../enums/gender.enum";

export interface Patient {
    id: number;
    name: string;
    surname: string;
    gender: Gender;
    socialSecurityNumber: number; //Social sec. num.
    corporationId: number;
 }
   
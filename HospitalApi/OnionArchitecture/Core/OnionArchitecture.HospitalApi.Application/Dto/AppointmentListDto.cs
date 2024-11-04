﻿using OnionArchitecture.HospitalApi.Domain.Enums;
using System;

namespace OnionArchitecture.HospitalApi.Application.Dto
{
    public class AppointmentListDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; } // Doktor kimliği (Foreign Key)

        public int PatientId { get; set; }

        public int ServiceId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; } // Randevu durumu (örneğin Beklemede, Tamamlandı, İptal)

    }
}

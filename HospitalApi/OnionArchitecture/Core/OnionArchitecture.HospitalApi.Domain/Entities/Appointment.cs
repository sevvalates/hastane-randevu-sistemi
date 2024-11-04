using OnionArchitecture.HospitalApi.Domain.Enums;
using System;

namespace OnionArchitecture.HospitalApi.Domain.Entities
{
    public class Appointment
    {

        public int Id { get; set; } // Benzersiz randevu kimliği

        public int DoctorId { get; set; } // Doktor kimliği (Foreign Key)
        public Doctor Doctor { get; set; } // Doktor ile ilişki

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; } // Randevu durumu (örneğin Beklemede, Tamamlandı, İptal)
    }
}

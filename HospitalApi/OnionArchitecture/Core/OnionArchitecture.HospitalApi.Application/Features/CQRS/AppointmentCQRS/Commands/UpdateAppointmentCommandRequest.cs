using MediatR;
using OnionArchitecture.HospitalApi.Domain.Enums;
using System;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands
{
    public class UpdateAppointmentCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int DoctorId { get; set; } // Doktor kimliği (Foreign Key)

        // public int PatientId { get; set; }

        public DateTime AppointmentDate { get; set; }  //???

        public AppointmentStatus AppointmentStatus { get; set; } // Randevu durumu (örneğin Beklemede, Tamamlandı, İptal)

    }
}

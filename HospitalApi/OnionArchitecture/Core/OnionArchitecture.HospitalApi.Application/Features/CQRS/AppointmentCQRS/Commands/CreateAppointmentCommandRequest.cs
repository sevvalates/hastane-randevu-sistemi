using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Enums;
using System;
using System.Globalization;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands
{
    public class CreateAppointmentCommandRequest : IRequest<CreatedAppointmentDto>
    {
        public int DoctorId { get; set; } // Doktor kimliği (Foreign Key)

        public int PatientId { get; set; }

        public int ServiceId { get; set; }

        public DateTime AppointmentDate { get; set; } //???

        //public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.Pending; // Randevu durumu (örneğin Beklemede, Tamamlandı, İptal)
        public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.NoShow;
    }

}


using OnionArchitecture.HospitalApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Dto
{
    public class AppointmentDetailDTO
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public Gender PatientGender { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; } // Add this property
        public AppointmentStatus AppointmentStatus { get; set; } // Add this property


        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
    }

}

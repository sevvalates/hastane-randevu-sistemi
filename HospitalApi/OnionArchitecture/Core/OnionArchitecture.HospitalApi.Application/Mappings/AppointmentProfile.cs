using AutoMapper;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;

namespace OnionArchitecture.HospitalApi.Application.Mappings
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            this.CreateMap<Appointment, AppointmentListDto>().ReverseMap();
            this.CreateMap<Appointment, CreatedAppointmentDto>().ReverseMap();
            this.CreateMap<Appointment, AppointmentDetailDTO>().ReverseMap();
        }
    }
}

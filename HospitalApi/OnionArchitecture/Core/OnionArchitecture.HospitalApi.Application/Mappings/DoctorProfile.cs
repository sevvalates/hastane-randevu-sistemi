using AutoMapper;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;

namespace OnionArchitecture.HospitalApi.Application.Mappings
{
    public class DoctorProfile : Profile
    {

        public DoctorProfile()
        {
            this.CreateMap<Doctor, DoctorListDto>().ReverseMap();
            this.CreateMap<Doctor, CreatedDoctorDto>().ReverseMap();
        }
    }
}

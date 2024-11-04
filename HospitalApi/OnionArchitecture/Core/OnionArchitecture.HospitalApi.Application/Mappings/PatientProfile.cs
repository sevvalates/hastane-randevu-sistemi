using AutoMapper;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;

namespace OnionArchitecture.HospitalApi.Application.Mappings
{
    public class PatientProfile : Profile
    {

        public PatientProfile()
        {
            this.CreateMap<Patient, PatientListDto>().ReverseMap();
            this.CreateMap<Patient, CreatedPatientDto>().ReverseMap();
        }
    }
}

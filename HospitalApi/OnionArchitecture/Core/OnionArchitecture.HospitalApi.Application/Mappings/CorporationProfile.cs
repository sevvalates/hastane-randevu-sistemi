using AutoMapper;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;


namespace OnionArchitecture.HospitalApi.Application.Mappings
{
    public class CorporationProfile : Profile
    {
        public CorporationProfile()
        {
            this.CreateMap<Corporation, CorporationListDto>().ReverseMap();
            this.CreateMap<Corporation, CreatedDoctorDto>().ReverseMap();
        }
    }
}

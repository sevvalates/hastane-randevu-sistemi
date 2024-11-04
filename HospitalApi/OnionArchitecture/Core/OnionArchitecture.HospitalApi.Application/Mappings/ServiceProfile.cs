using AutoMapper;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;

namespace OnionArchitecture.HospitalApi.Application.Mappings
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            this.CreateMap<Service, ServiceListDto>().ReverseMap();
            this.CreateMap<Service, CreatedServiceDto>().ReverseMap();
        }
    }
}

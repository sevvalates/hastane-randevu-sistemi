using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Queries
{
    public class GetServiceQueryRequest : IRequest<ServiceListDto>
    {

        public int Id { get; set; }
        public GetServiceQueryRequest(int ıd)
        {
            Id = ıd;
        }
    }
}

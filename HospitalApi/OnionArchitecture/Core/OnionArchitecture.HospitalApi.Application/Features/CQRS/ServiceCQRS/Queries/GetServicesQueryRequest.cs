using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Queries
{
    public class GetServicesQueryRequest : IRequest<List<ServiceListDto>>
    {
    }
}

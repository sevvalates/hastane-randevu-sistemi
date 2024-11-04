using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Queries
{
    public class GetCorporationsQueryRequest : IRequest<List<CorporationListDto>>
    {
    }
}

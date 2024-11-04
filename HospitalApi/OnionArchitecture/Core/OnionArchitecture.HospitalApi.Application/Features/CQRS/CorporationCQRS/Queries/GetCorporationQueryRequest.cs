using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Queries
{
    public class GetCorporationQueryRequest : IRequest<CorporationListDto>
    {
        public int Id { get; set; }

        public GetCorporationQueryRequest(int id)
        {
            Id = id;
        }
    }
}

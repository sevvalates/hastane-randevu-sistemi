using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands
{
    public class CreateCorporationCommandRequest : IRequest<CreatedCorporationDto>
    {
        public string Name { get; set; }
    }
}

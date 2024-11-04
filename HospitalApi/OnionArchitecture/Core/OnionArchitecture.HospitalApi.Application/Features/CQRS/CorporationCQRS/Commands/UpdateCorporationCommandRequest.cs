using MediatR;


namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands
{
    public class UpdateCorporationCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands
{
    public class RemoveCorporationCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveCorporationCommandRequest(int ıd)
        {
            Id = ıd;
        }
    }
}

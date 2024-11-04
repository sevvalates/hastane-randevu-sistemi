using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands
{
    public class UpdateServiceCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands
{
    public class RemoveServiceCommandRequest : IRequest
    {

        public int Id { get; set; }

        public RemoveServiceCommandRequest(int id)
        {
            Id = id;
        }
    }
}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands
{
    public class CreateServiceCommandRequest : IRequest<CreatedServiceDto>
    {
        public string Name { get; set; }
    }
}

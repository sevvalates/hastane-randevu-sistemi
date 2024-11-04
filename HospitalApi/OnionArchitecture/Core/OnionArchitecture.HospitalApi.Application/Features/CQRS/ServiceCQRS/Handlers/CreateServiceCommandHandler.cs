using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Handlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommandRequest, CreatedServiceDto>
    {

        private readonly IRepository<Service> repository;
        private readonly IMapper mapper;

        public CreateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedServiceDto> Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var service = new Service { Name = request.Name };
            await repository.CreateAsync(service);
            return mapper.Map<CreatedServiceDto>(service);
        }
    }
}

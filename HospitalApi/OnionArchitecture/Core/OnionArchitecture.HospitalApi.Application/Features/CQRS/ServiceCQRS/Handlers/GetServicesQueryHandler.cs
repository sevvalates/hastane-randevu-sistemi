using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Handlers
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQueryRequest, List<ServiceListDto>>
    {

        private readonly IRepository<Service> repository;
        private readonly IMapper mapper;

        public GetServicesQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ServiceListDto>> Handle(GetServicesQueryRequest request, CancellationToken cancellationToken)
        {
            var services = await repository.GetAllAsync();
            return mapper.Map<List<ServiceListDto>>(services);
        }

    }
}

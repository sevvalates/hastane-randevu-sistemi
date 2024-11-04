using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Handlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQueryRequest, ServiceListDto>
    {

        private readonly IRepository<Service> repository;
        private readonly IMapper mapper;

        public GetServiceQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ServiceListDto> Handle(GetServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByFilterAsync(x => x.Id == request.Id);
            return mapper.Map<ServiceListDto>(data); //datayı servicelistdto ya çevir
        }

    }
}

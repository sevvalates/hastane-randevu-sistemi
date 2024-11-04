using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Handlers
{
    public class GetCorporationsQueryHandler : IRequestHandler<GetCorporationsQueryRequest, List<CorporationListDto>>
    {

        private readonly IRepository<Corporation> repository;
        private readonly IMapper mapper;

        public GetCorporationsQueryHandler(IRepository<Corporation> repository, IMapper mapper
            )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<CorporationListDto>> Handle(GetCorporationsQueryRequest request, CancellationToken cancellationToken)
        {
            var corporations = await repository.GetAllAsync();
            return mapper.Map<List<CorporationListDto>>(corporations);
        }

    }
}

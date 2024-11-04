using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Handlers
{
    public class GetCorporationQueryHandler : IRequestHandler<GetCorporationQueryRequest, CorporationListDto>
    {

        private readonly IRepository<Corporation> repository;
        private readonly IMapper mapper;

        public GetCorporationQueryHandler(IRepository<Corporation> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CorporationListDto> Handle(GetCorporationQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByFilterAsync(x => x.Id == request.Id);
            return mapper.Map<CorporationListDto>(data);
        }
    }
}

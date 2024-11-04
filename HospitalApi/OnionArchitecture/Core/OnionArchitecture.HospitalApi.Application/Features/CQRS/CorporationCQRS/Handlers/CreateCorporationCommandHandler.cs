using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Handlers
{
    public class CreateCorporationCommandHandler : IRequestHandler<CreateCorporationCommandRequest, CreatedCorporationDto>
    {
        private readonly IRepository<Corporation> repository;
        private readonly IMapper mapper;

        public CreateCorporationCommandHandler(IRepository<Corporation> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedCorporationDto> Handle(CreateCorporationCommandRequest request, CancellationToken cancellationToken)
        {
            var corporation = new Corporation { Name = request.Name };
            await repository.CreateAsync(corporation);
            return mapper.Map<CreatedCorporationDto>(corporation);
        }
    }

}

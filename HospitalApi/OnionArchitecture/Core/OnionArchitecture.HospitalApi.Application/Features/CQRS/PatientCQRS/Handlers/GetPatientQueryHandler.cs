using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Handlers
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQueryRequest, PatientListDto>
    {

        private readonly IRepository<Patient> repository;
        private readonly IMapper mapper;

        public GetPatientQueryHandler(IRepository<Patient> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<PatientListDto> Handle(GetPatientQueryRequest request, CancellationToken cancellationToken)
        {
            Patient data = null; // ?? var data idi
            //kontorlleri silip x.social... olan kalack
            if (request.Id != 0)
            {
                data = await repository.GetByFilterAsync(x => x.Id == request.Id);
            }
            else
            {
                data = await repository.GetByFilterAsync(x => x.SocialSecurityNumber == request.SocialSecurityNumber);
            }
            return mapper.Map<PatientListDto>(data);
        }
    }
}

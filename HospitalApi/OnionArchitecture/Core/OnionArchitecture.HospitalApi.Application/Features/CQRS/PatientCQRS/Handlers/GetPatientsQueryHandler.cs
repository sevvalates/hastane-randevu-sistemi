using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Handlers
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQueryRequest, List<PatientListDto>>
    {
        private readonly IRepository<Patient> repository;
        private readonly IMapper mapper;

        public GetPatientsQueryHandler(IRepository<Patient> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<PatientListDto>> Handle(GetPatientsQueryRequest request, CancellationToken cancellationToken)
        {
            var patients = await repository.GetAllAsync();
            return mapper.Map<List<PatientListDto>>(patients);
        }
    }
}

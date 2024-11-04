using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Handlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommandRequest, CreatedPatientDto>
    {
        private readonly IRepository<Patient> repository;
        private readonly IMapper mapper;

        public CreatePatientCommandHandler(IRepository<Patient> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedPatientDto> Handle(CreatePatientCommandRequest request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                Name = request.Name,
                Surname = request.Surname,
                Gender = request.Gender,
                SocialSecurityNumber = request.SocialSecurityNumber,
                CorporationId = request.CorporationId,
            };

            await repository.CreateAsync(patient);

            return mapper.Map<CreatedPatientDto>(patient);
        }
    }
}

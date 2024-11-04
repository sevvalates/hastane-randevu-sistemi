using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Handlers
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommandRequest, CreatedDoctorDto>
    {

        private readonly IRepository<Doctor> repository;
        private readonly IMapper mapper;

        public CreateDoctorCommandHandler(IRepository<Doctor> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedDoctorDto> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                Name = request.Name,
                Surname = request.Surname,
                SocialSecurityNumber = request.SocialSecurityNumber,
                Gender = request.Gender,
                ServiceId = request.ServiceId,
            };

            await repository.CreateAsync(doctor);

            return mapper.Map<CreatedDoctorDto>(doctor);
        }


    }
}

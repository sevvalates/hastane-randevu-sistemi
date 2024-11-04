using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Handlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommandRequest>
    {

        private readonly IRepository<Patient> repository;

        public UpdatePatientCommandHandler(IRepository<Patient> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdatePatientCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Name = request.Name;
                updatedEntity.Surname = request.Surname;
                updatedEntity.Gender = request.Gender;
                updatedEntity.SocialSecurityNumber = request.SocialSecurityNumber;
                updatedEntity.CorporationId = request.CorporationId;

                await repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;

        }
    }
}

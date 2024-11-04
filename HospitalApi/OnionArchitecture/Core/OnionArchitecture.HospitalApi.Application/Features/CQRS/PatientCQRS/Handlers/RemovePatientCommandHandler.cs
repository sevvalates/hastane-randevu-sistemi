using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Handlers
{
    public class RemovePatientCommandHandler : IRequestHandler<RemovePatientCommandRequest>
    {
        private readonly IRepository<Patient> repository;

        public RemovePatientCommandHandler(IRepository<Patient> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemovePatientCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await repository.Remove(deletedEntity);
            }
            return Unit.Value;
        }
    }
}

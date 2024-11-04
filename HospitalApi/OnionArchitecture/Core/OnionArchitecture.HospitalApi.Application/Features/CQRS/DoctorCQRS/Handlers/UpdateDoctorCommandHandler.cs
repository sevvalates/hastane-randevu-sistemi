using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Handlers
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommandRequest>
    {

        private readonly IRepository<Doctor> repository;

        public UpdateDoctorCommandHandler(IRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Name = request.Name;
                updatedEntity.Surname = request.Surname;
                updatedEntity.SocialSecurityNumber = request.SocialSecurityNumber;
                updatedEntity.Gender = request.Gender;
                updatedEntity.ServiceId = request.ServiceId;

                await repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}

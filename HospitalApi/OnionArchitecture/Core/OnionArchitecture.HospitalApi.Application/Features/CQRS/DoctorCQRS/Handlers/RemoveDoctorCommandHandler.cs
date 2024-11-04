using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Handlers
{
    public class RemoveDoctorCommandHandler : IRequestHandler<RemoveDoctorCommandRequest>
    {

        private readonly IRepository<Doctor> repository;

        public RemoveDoctorCommandHandler(IRepository<Doctor> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveDoctorCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await repository.Remove(deletedEntity);
            }   //aslında direkt silmeden remove işleminde bir update yapmak 
                // bir isDeleted veya isActive gibi bir property i true false setlemek daha mantıklı
            return Unit.Value;

        }
    }

}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest>
    {

        private readonly IRepository<Service> repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Name = request.Name;

                await repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;

        }
    }
}

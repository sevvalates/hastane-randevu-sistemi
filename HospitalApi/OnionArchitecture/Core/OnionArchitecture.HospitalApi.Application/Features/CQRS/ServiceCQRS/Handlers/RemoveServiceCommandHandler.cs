using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Handlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommandRequest>
    {

        private readonly IRepository<Service> repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveServiceCommandRequest request, CancellationToken cancellationToken)
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

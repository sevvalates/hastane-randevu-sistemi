using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Handlers
{
    public class RemoveCorporationCommandHandler : IRequestHandler<RemoveCorporationCommandRequest>
    {
        private readonly IRepository<Corporation> repository;
        public RemoveCorporationCommandHandler(IRepository<Corporation> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RemoveCorporationCommandRequest request, CancellationToken cancellationToken)
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

using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Handlers
{
    public class UpdateCorporationCommandHandler : IRequestHandler<UpdateCorporationCommandRequest>
    {
        private readonly IRepository<Corporation> repository;

        public UpdateCorporationCommandHandler(IRepository<Corporation> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCorporationCommandRequest request, CancellationToken cancellationToken)
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

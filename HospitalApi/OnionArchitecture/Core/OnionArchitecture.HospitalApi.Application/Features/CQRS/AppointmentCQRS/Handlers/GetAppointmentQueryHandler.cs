using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Handlers
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQueryRequest, AppointmentListDto>
    {

        private readonly IRepository<Appointment> repository;
        private readonly IMapper mapper;

        public GetAppointmentQueryHandler(IRepository<Appointment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<AppointmentListDto> Handle(GetAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByFilterAsync(x => x.Id == request.Id);
            return mapper.Map<AppointmentListDto>(data);
        }
    }
}

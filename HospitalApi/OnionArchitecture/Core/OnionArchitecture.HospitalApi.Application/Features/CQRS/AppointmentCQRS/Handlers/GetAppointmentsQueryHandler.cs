using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Handlers
{
    public class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQueryRequest, List<AppointmentDetailDTO>>
    {
        private readonly IRepository<Appointment> repository;
        private readonly IMapper mapper;

        public GetAppointmentsQueryHandler(IRepository<Appointment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<AppointmentDetailDTO>> Handle(GetAppointmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var appointments = await repository.GetAllAsyncDetail();
            return mapper.Map<List<AppointmentDetailDTO>>(appointments);
        }


    }
}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Queries
{
    public class GetAppointmentsQueryRequest : IRequest<List<AppointmentDetailDTO>>
    {

    }
}

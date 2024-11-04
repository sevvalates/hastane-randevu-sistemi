using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Queries
{
    public class GetAppointmentQueryRequest : IRequest<AppointmentListDto>
    {
        public int Id { get; set; }

        public GetAppointmentQueryRequest(int id)
        {
            Id = id;
        }

    }
}

using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands
{
    public class RemoveAppointmentCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveAppointmentCommandRequest(int id)
        {
            Id = id;
        }
    }
}

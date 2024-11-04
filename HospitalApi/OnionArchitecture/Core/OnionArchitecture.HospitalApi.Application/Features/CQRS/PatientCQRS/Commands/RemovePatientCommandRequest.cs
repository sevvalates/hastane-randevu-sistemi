using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands
{
    public class RemovePatientCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemovePatientCommandRequest(int id)
        {
            Id = id;
        }
    }
}

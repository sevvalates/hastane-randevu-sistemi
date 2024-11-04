using MediatR;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Commands
{
    public class RemoveDoctorCommandRequest : IRequest
    {

        public int Id { get; set; }

        public RemoveDoctorCommandRequest(int id)
        {
            Id = id;
        }
    }
}

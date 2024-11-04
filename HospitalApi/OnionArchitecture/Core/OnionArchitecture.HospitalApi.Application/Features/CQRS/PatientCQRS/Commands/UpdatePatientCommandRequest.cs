using MediatR;
using OnionArchitecture.HospitalApi.Domain.Enums;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands
{
    public class UpdatePatientCommandRequest : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }
        public long SocialSecurityNumber { get; set; }

        public int CorporationId { get; set; }
    }
}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands
{
    public class CreatePatientCommandRequest : IRequest<CreatedPatientDto>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public long SocialSecurityNumber { get; set; }

        public int CorporationId { get; set; }
    }
}

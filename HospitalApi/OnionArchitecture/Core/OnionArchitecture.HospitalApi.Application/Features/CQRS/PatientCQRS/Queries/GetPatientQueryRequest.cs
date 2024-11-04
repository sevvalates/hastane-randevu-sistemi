using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Queries
{
    public class GetPatientQueryRequest : IRequest<PatientListDto>
    {
        public long SocialSecurityNumber { get; set; }

        public GetPatientQueryRequest(long socialSecurityNumber)
        {
            SocialSecurityNumber = socialSecurityNumber;
        }

        //25.10.24 eklendi
        public int Id { get; set; }


        public GetPatientQueryRequest(int ıd)
        {
            Id = ıd;
        }

        public GetPatientQueryRequest(long socialSecurityNumber, int ıd) : this(socialSecurityNumber)
        {
            Id = ıd;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}

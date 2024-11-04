using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;


namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Queries
{
    public class GetDoctorQueryRequest : IRequest<DoctorListDto>
    {
        public long SocialSecurityNumber { get; set; }

        public GetDoctorQueryRequest(long socialSecurityNumber)
        {
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Queries
{
    public class GetDoctorsQueryRequest : IRequest<List<DoctorListDto>>
    {
    }
}

using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Queries
{
    public class GetPatientsQueryRequest : IRequest<List<PatientListDto>>
    {
    }
}

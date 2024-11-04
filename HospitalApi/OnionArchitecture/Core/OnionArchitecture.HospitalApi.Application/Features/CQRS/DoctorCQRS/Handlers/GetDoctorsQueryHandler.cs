using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Handlers
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQueryRequest, List<DoctorListDto>>
    {

        private readonly IRepository<Doctor> repository;
        private readonly IMapper mapper;

        public GetDoctorsQueryHandler(IRepository<Doctor> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<DoctorListDto>> Handle(GetDoctorsQueryRequest request, CancellationToken cancellationToken)
        {
            var doctors = await repository.GetAllAsync();
            return mapper.Map<List<DoctorListDto>>(doctors);
        }

    }
}

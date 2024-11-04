using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Queries;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Handlers
{
    // burdaki interfaceler mediatr pattern e hizmet ediyo
    // hangi query e karşılık hangi handler ı çalıştırcağı
    // request alıyo listDto dönüyo
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQueryRequest, DoctorListDto>
    {

        private readonly IRepository<Doctor> repository;
        private readonly IMapper mapper;

        public GetDoctorQueryHandler(IRepository<Doctor> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DoctorListDto> Handle(GetDoctorQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await repository.GetByFilterAsync(x => x.SocialSecurityNumber == request.SocialSecurityNumber);
            return mapper.Map<DoctorListDto>(data); //datayı doctorlistdto ya çevir
        }
    }
}

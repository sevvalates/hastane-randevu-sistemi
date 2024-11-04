using OnionArchitecture.HospitalApi.Domain.Enums;

namespace OnionArchitecture.HospitalApi.Application.Dto
{
    public class DoctorListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long SocialSecurityNumber { get; set; }
        public Gender Gender { get; set; }
        public int ServiceId { get; set; }

    }
}

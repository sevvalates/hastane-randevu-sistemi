using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Domain.Entities
{
    public class Corporation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Patient> Patients { get; set; }


    }
}

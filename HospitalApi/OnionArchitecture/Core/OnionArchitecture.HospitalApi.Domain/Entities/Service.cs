using System.Collections.Generic;

namespace OnionArchitecture.HospitalApi.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One-to-Many Relationship
        public List<Doctor> Doctors { get; set; } // List yerine ICollection 

        public List<Appointment> Appointments { get; set; }

    }
}

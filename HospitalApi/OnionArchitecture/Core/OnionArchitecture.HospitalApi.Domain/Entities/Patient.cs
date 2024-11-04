using OnionArchitecture.HospitalApi.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.HospitalApi.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }


        
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        
        public string Name { get; set; }

        
        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters.")]
       
        public string Surname { get; set; }

        
        [Required(ErrorMessage = "Gender information is required.")]
        
        public Gender Gender { get; set; }

        
        [Required(ErrorMessage = "Social Security Number is required.")]
        [Range(10000000000, 99999999999, ErrorMessage = "Social Security Number must be a 11-digit number.")]
        
        public long SocialSecurityNumber { get; set; }

        
        [Required(ErrorMessage = "Corporation is required.")]
        
        public int CorporationId { get; set; }

        public Corporation Corporation { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>(); // Hastanın randevuları
    }
}

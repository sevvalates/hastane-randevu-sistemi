using OnionArchitecture.HospitalApi.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.HospitalApi.Domain.Entities
{
    public class Doctor
    {

        public int Id { get; set; }



        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters.")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Social Security Number is required.")]
        [Range(10000000000, 99999999999, ErrorMessage = "Social Security Number must be a 11-digit number.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Social Security Number must contain only numbers.")]
        public long SocialSecurityNumber { get; set; }


        [Required(ErrorMessage = "Gender information is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Service is required.")]

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public List<Appointment> Appointments { get; set; } // Doktorun randevuları


    }
}

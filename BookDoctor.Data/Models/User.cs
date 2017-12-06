namespace BookDoctor.Data.Models
{
    using BookDoctor.Data.Models.EnumTypes;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        
        public Sex Sex { get; set; }
        
        public string Info { get; set; }
        
        public bool IsDoctor { get; set; }
        
        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public int MedicalCenterId { get; set; }

        public MedicalCenter MedicalCenter { get; set; }

        public List<Appointment> DoctorAppointments { get; set; } = new List<Appointment>();

        public List<Appointment> PatientAppointments { get; set; } = new List<Appointment>();        
    }
}

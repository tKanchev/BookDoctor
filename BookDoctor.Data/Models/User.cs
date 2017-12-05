namespace BookDoctor.Data.Models
{
    using BookDoctor.Data.Models.EnumTypes;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public Sex Sex { get; set; }

        public string Major { get; set; }

        public string Info { get; set; }

        //Phone

        public bool IsDoctor { get; set; }
        
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();        
    }
}

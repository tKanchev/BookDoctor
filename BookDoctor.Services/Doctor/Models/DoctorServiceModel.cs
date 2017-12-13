using BookDoctor.Common.Mapping;
using BookDoctor.Data.Models;
using System.Collections.Generic;

namespace BookDoctor.Services.Doctor.Models
{
    public class DoctorServiceModel : IMapFrom<User>
    {       
        public string Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Info { get; set; }
        
        public Specialty Specialty { get; set; }
        
        public MedicalCenter MedicalCenter { get; set; }
        
        public List<Appointment> PatientAppointments { get; set; } = new List<Appointment>();
    }
}

namespace BookDoctor.Services.Doctor.Models
{
    using BookDoctor.Common.Mapping;
    using BookDoctor.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DoctorAppointmentServiceModel : IMapFrom<Appointment>
    {
        public int Id { get; set; }

        public string Info { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
                
        public TimeSpan TimeStart { get; set; }
        
        public TimeSpan TimeEnd { get; set; }
        
        public User Patient { get; set; }
    }
}

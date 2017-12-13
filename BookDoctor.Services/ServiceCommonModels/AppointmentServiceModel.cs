namespace BookDoctor.Services.ServiceCommonModels
{
    using BookDoctor.Common.Mapping;
    using BookDoctor.Data.Models;
    using System;

    public class AppointmentServiceModel : IMapFrom<Appointment>
    {
        public int Id { get; set; }

        public string Info { get; set; }
        
        public DateTime Date { get; set; }
        
        public TimeSpan TimeStart { get; set; }
        
        public TimeSpan TimeEnd { get; set; }
        
        public string DoctorId { get; set; }

        public User Doctor { get; set; }
        
        public string PatientId { get; set; }

        public User Patient { get; set; }
    }
}

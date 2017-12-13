namespace BookDoctor.Web.Areas.Patients.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PatientAppointmentsListViewModel
    {        
        public string Info { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
                
        public TimeSpan TimeStart { get; set; }
                
        public TimeSpan TimeEnd { get; set; }
                
        public string DoctorName { get; set; }
    }
}

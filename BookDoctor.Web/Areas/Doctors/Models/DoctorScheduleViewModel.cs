namespace BookDoctor.Web.Areas.Doctors.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DoctorScheduleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }        
    }
}

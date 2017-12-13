namespace BookDoctor.Web.Areas.Patients.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PatientAppointmentFormViewModel
    {
        public int Id { get; set; }

        public string Info { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeStart { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeEnd { get; set; }

        [Required]
        public string DoctorId { get; set; }

        public IEnumerable<SelectListItem> Doctors { get; set; }
    }
}

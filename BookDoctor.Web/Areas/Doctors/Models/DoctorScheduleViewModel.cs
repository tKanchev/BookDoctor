namespace BookDoctor.Web.Areas.Doctors.Models
{
    using BookDoctor.Services.ServiceCommonModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DoctorScheduleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<AppointmentServiceModel> Appointments { get; set; }
    }
}

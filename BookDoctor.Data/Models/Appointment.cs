namespace BookDoctor.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Appointment
    {
        public int Id { get; set; }

        public string Info { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan TimeStart { get; set; }

        [Required]
        public TimeSpan TimeEnd { get; set; }

        [Required]
        public string DoctorId { get; set; }

        public User Doctor { get; set; }

        [Required]
        public string PatientId { get; set; }

        public User Patient { get; set; }
    }
}

using System.Collections.Generic;

namespace BookDoctor.Data.Models
{
    public class MedicalCenter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<User> Doctors { get; set; } = new List<User>();
    }
}

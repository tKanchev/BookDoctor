namespace BookDoctor.Data.Models
{
    using System.Collections.Generic;

    public class Specialty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> Doctors { get; set; }
    }
}

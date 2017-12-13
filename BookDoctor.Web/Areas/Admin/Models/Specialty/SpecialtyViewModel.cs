namespace BookDoctor.Web.Areas.Admin.Models.Specialty
{
    using BookDoctor.Data.Models;
    using System.Collections.Generic;

    public class SpecialtyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> Doctors { get; set; } = new List<User>();
    }
}

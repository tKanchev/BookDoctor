namespace BookDoctor.Services.Admin.Models.Specialty
{
    using BookDoctor.Common.Mapping;
    using Data.Models;
    using System.Collections.Generic;

    public class SpecialtyServiceModel : IMapFrom<Specialty>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<User> Doctors { get; set; } = new List<User>();
    }
}

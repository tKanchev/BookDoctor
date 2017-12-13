namespace BookDoctor.Services.Admin.Models.MedicalCenter
{
    using BookDoctor.Common.Mapping;
    using BookDoctor.Data.Models;
    using System.Collections.Generic;

    public class MedicalCanterServiceModel : IMapFrom<MedicalCenter>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public List<User> Doctors { get; set; } = new List<User>();
    }
}

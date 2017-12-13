namespace BookDoctor.Web.Areas.Admin.Models.MedicalCenter
{
    using BookDoctor.Common.Mapping;
    using BookDoctor.Data;
    using BookDoctor.Data.Models;
    using BookDoctor.Services.Admin.Models.MedicalCenter;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MedicalCenterViewModel : IMapFrom<MedicalCanterServiceModel>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.NameMinLength)]
        [MaxLength(DataConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Location { get; set; }

        public List<User> Doctors { get; set; }
    }
}

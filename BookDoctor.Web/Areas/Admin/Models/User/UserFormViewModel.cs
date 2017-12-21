namespace BookDoctor.Web.Areas.Admin.Models.User
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class UserFormViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDoctor { get; set; }

        public int? SpecialtyId { get; set; }

        public IEnumerable<SelectListItem> Specialties { get; set; }

        public int? MedicalCenterId { get; set; }

        public IEnumerable<SelectListItem> MedicalCenters { get; set; }
    }
}

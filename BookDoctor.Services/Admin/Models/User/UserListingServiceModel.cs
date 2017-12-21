namespace BookDoctor.Services.Admin.Models.User
{
    using BookDoctor.Common.Mapping;
    using Data.Models;

    public class UserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsDoctor { get; set; }

        public Specialty Specialty { get; set; }

        public MedicalCenter MedicalCenter { get; set; }
    }
}

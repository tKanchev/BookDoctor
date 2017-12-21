namespace BookDoctor.Services.Admin
{
    using BookDoctor.Data.Models;
    using BookDoctor.Services.Admin.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<UserListingServiceModel>> AllAsync();

        Task<User> GetByIdAsync(string userId);

        Task EditAsync(string userId,
            string firstName,
            string lastName,
            int? medCenterId,
            int? specialtyId);
    }
}

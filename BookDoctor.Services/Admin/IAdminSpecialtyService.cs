namespace BookDoctor.Services.Admin
{
    using BookDoctor.Services.Admin.Models.Specialty;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminSpecialtyService
    {
        Task AddAsync(string name);

        Task<IEnumerable<SpecialtyServiceModel>> AllAsync();

        Task<bool> SpecialtyExists(int id);
    }
}

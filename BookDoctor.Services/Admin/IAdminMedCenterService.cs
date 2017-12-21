namespace BookDoctor.Services.Admin
{
    using BookDoctor.Services.Admin.Models.MedicalCenter;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminMedCenterService
    {
        Task AddAsync(string name,
            string location);

        Task<IEnumerable<MedicalCanterServiceModel>> AllAsync();

        Task<bool> MedCenterExists(int id);
    }
}

namespace BookDoctor.Services.Admin.Implementations
{
    using System.Threading.Tasks;
    using BookDoctor.Data;
    using BookDoctor.Data.Models;
    using BookDoctor.Services.Admin.Models.MedicalCenter;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class AdminMedCenterService : IAdminMedCenterService
    {
        private readonly BookDoctorDbContext db;

        public AdminMedCenterService(BookDoctorDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(string name, string location)
        {
            var medCenter = new MedicalCenter
            {
                Name = name,
                Location = location
            };

            await this.db.AddAsync(medCenter);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalCanterServiceModel>> AllAsync()
            => await this.db
                    .MedicalCenters
                    .ProjectTo<MedicalCanterServiceModel>()
                    .ToListAsync();

    }
}

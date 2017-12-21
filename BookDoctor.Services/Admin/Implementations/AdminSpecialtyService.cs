namespace BookDoctor.Services.Admin.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookDoctor.Data;
    using BookDoctor.Services.Admin.Models.Specialty;
    using BookDoctor.Data.Models;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    public class AdminSpecialtyService : IAdminSpecialtyService
    {
        private readonly BookDoctorDbContext db;

        public AdminSpecialtyService(BookDoctorDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(string name)
        {
            var specialty = new Specialty
            {
                Name = name
            };

            bool specialtyExists = this.db
                .Specialties
                .Any(s => s.Name.ToLower() == name.ToLower());
                
            if (!specialtyExists)
            {
                await this.db.Specialties.AddAsync(specialty);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SpecialtyServiceModel>> AllAsync()
            => await this.db
                .Specialties
                .ProjectTo<SpecialtyServiceModel>()
                .ToListAsync();

        public async Task<bool> SpecialtyExists(int id)
            => await this.db.Specialties.AnyAsync(s => s.Id == id);
    }
}

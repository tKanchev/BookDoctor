namespace BookDoctor.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookDoctor.Data;
    using BookDoctor.Services.Admin.Models.User;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookDoctor.Data.Models;

    public class AdminUserService : IAdminUserService
    {
        private readonly BookDoctorDbContext db;

        private readonly IAdminSpecialtyService specialties;
        private readonly IAdminMedCenterService medCenters;

        public AdminUserService(BookDoctorDbContext db,
            IAdminSpecialtyService specialties,
            IAdminMedCenterService medCenters)
        {
            this.db = db;
            this.specialties = specialties;
            this.medCenters = medCenters;
        }

        public async Task<IEnumerable<UserListingServiceModel>> AllAsync()
            => await this.db
                .Users
                .ProjectTo<UserListingServiceModel>()
                .ToListAsync();

        public async Task EditAsync(string userId, 
            string firstName, 
            string lastName, 
            int? medCenterId, 
            int? specialtyId)
        {
            var user = await this.db.Users.FindAsync(userId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not exists!");
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            if (user.IsDoctor)
            {
                user.MedicalCenterId = medCenterId;
                user.SpecialtyId = specialtyId;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(string userId)
            => await this.db
                .Users
                .FindAsync(userId);
    }
}

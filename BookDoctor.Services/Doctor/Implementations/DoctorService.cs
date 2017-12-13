namespace BookDoctor.Services.Doctor.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BookDoctor.Data;
    using BookDoctor.Services.Doctor.Models;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class DoctorService : IDoctorService
    {
        public BookDoctorDbContext db;

        public DoctorService(BookDoctorDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<DoctorServiceModel>> AllAsync()
            => await this.db
                    .Users
                    .Where(u => u.IsDoctor)
                    .ProjectTo<DoctorServiceModel>()
                    .ToListAsync();        
    }
}

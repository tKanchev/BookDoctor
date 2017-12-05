namespace BookDoctor.Data
{
    using BookDoctor.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class BookDoctorDbContext : IdentityDbContext<User>
    {
        public BookDoctorDbContext(DbContextOptions<BookDoctorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<Location> Locations { get; set; }

        public DbSet<Specialty> Specialties { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            builder
                .Entity<User>()
                .HasOne(dr => dr.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(dr => dr.SpecialtyId);

            builder
                .Entity<User>()
                .HasOne(dr => dr.Location)
                .WithMany(l => l.Doctors)
                .HasForeignKey(dr => dr.LocationId);

            base.OnModelCreating(builder);
        }
    }
}

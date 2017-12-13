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

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(dr => dr.DoctorAppointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.PatientAppointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MedicalCenter>()
                .HasMany(mc => mc.Doctors)
                .WithOne(dr => dr.MedicalCenter)
                .HasForeignKey(dr => dr.MedicalCenterId);

            builder
                .Entity<Specialty>()
                .HasMany(s => s.Doctors)
                .WithOne(dr => dr.Specialty)
                .HasForeignKey(dr => dr.SpecialtyId);

            base.OnModelCreating(builder);
        }
    }
}

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
                .Entity<User>()
                .HasOne(dr => dr.Specialty)
                .WithMany(s => s.Doctors)
                .HasForeignKey(dr => dr.SpecialtyId);

            builder
                .Entity<User>()
                .HasOne(dr => dr.MedicalCenter)
                .WithMany(mc => mc.Doctors)
                .HasForeignKey(dr => dr.MedicalCenterId);

            base.OnModelCreating(builder);
        }
    }
}

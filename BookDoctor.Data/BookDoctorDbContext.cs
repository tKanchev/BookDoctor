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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OSIRIS.Database.Domain;

namespace OSIRIS.Database
{
    public class OSIRISDbContext : DbContext
    {
        public OSIRISDbContext(DbContextOptions<OSIRISDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}

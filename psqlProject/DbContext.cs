using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace psqlProject
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        public ApplicationContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=DbNew;username=postgres;password=0550");
        }
    }
}
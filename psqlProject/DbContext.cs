using Microsoft.EntityFrameworkCore;

namespace psqlProject
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=postgres;username=postgres;password=0550");
        }
    }
}
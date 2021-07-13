using Microsoft.EntityFrameworkCore;

namespace psqlProject
{
    public class ApplicationContext : DbContext
    {
        public string ConnectString;
        public DbSet<Log> Logs { get; set; }

        public ApplicationContext(string connectString)
        {
            ConnectString = connectString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("host=localhost;port=5432;database=DbNew;username=postgres;password=0550");
            optionsBuilder.UseNpgsql(ConnectString);
        }
    }
}
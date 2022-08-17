using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    
        // Bakers is what the DB table will be called (bellow)
        // this is _context.Bakers
        // BDSet<Baker> means: data from the database, which is mapped to the Baker model
        public DbSet<Baker> Bakers { get; set; }

        public DbSet<Bread> Breads { get; set; }

    }
}
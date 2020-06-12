using MemGrow.App.Domain.Seeding;
using Microsoft.EntityFrameworkCore;

namespace MemGrow.App.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext)
        {

        }

        public DbSet<Seed> Seeds { get; set; }

        public DbSet<SeedCategory> SeedCategories { get; set; }
    }
}

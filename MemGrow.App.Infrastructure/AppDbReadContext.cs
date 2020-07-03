using MemGrow.App.Domain.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MemGrow.App.Infrastructure
{
    public class AppDbReadContext 
    {
        private readonly AppDbContext _dbContext;

        public AppDbReadContext(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Seed> Seeds => _dbContext.Set<Seed>().AsNoTracking();

        public IQueryable<SeedCategory> SeedCategorys => _dbContext.Set<SeedCategory>().AsNoTracking();
    }
}
using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.GetSeedCategories;
using System.Linq;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfGetSeedCategories : IGetSeedCategories
    {
        private readonly AppDbContext _context;

        public EfGetSeedCategories(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<SeedCategory> Get()
        {
            return _context.SeedCategories;
        }
    }
}
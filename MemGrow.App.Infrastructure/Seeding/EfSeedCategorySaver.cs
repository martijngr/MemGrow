using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.AddSeedCategories;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfSeedCategorySaver : ISeedCategorySaver
    {
        private readonly AppDbContext _context;

        public EfSeedCategorySaver(AppDbContext context)
        {
            _context = context;
        }

        public int Save(SeedCategory seedCategory)
        {
            _context.SeedCategories.Add(seedCategory);
            return _context.SaveChanges();
        }
    }
}

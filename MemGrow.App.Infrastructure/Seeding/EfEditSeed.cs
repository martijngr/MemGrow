using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.EditSeed;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfEditSeed : IEditSeed
    {
        private readonly AppDbContext _context;

        public EfEditSeed(AppDbContext context)
        {
            _context = context;
        }
        public void EditSeed(Seed seed)
        {
            var dbSeed = _context.Seeds.Find(seed.Id);

            dbSeed.SeedCategoryId = seed.SeedCategoryId;
            dbSeed.Description = seed.Description;

            _context.SaveChanges();
        }
    }
}

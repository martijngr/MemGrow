using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.GetSeedById;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfGetSeedById : IGetSeedById
    {
        private readonly AppDbContext _context;

        public EfGetSeedById(AppDbContext context)
        {
            _context = context;
        }
        public Seed GetById(int seedId)
        {
            return _context.Seeds.Find(seedId);
        }
    }
}

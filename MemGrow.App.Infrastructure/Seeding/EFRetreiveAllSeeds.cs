using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.GetSeeds;
using System.Linq;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EFRetreiveAllSeeds : IRetreiveAllSeeds
    {
        private readonly AppDbReadContext _context;

        public EFRetreiveAllSeeds(AppDbReadContext context)
        {
            _context = context;
        }

        public IQueryable<Seed> GetAll()
        {
            return _context.Seeds;
        }
    }
}

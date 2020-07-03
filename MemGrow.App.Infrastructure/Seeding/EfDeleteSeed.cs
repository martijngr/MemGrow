using MemGrow.App.Domain.Seeding.DeleteSeed;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfDeleteSeed : IDeleteSeed
    {
        private readonly AppDbContext _context;

        public EfDeleteSeed(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteSeed(int seedId)
        {
            var seed = _context.Seeds.Find(seedId);
            _context.Seeds.Remove(seed);

            _context.SaveChanges();
        }
    }
}

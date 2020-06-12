using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.AddSeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemGrow.App.Infrastructure.Seeding
{
    public class EfSeedSaver : ISeedSaver
    {
        private readonly AppDbContext _context;

        public EfSeedSaver(AppDbContext context)
        {
            _context = context;
        }

        public int Save(Seed seed)
        {
            _context.Seeds.Add(seed);
            _context.SaveChanges();

            return seed.Id;
        }
    }
}

using System.Linq;

namespace MemGrow.App.Domain.Seeding.GetSeeds
{
    public interface IRetreiveAllSeeds
    {
        IQueryable<Seed> GetAll();
    }
}

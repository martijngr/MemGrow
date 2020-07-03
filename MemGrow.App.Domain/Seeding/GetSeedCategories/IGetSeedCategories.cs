using System.Linq;

namespace MemGrow.App.Domain.Seeding.GetSeedCategories
{
    public interface IGetSeedCategories
    {
        IQueryable<SeedCategory> Get();
    }
}

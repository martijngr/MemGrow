using Common.Cqs;
using System.Collections.Generic;
using System.Linq;

namespace MemGrow.App.Domain.Seeding.GetSeedCategories
{
    public class GetSeedCategoriesQuery : IQuery<IEnumerable<SeedCategoryDto>>
    {
    }

    public class GetSeedCategoriesQueryHandler : IQueryHandler<GetSeedCategoriesQuery, IEnumerable<SeedCategoryDto>>
    {
        private readonly IGetSeedCategories _getSeedCategories;

        public GetSeedCategoriesQueryHandler(IGetSeedCategories getSeedCategories)
        {
            _getSeedCategories = getSeedCategories;
        }

        public IEnumerable<SeedCategoryDto> Handle(GetSeedCategoriesQuery query)
        {
            return _getSeedCategories.Get().Select(c => new SeedCategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
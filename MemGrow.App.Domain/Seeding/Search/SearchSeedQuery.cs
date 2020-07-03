using Common.Cqs;
using MemGrow.App.Domain.Seeding.GetSeeds;
using System.Collections.Generic;
using System.Linq;

namespace MemGrow.App.Domain.Seeding.Search
{
    public class SearchSeedQuery : IQuery<IEnumerable<SeedSearchResultDto>>
    {
        public string Keyword { get; set; }
    }

    public class SearchSeedQueryHandler : IQueryHandler<SearchSeedQuery, IEnumerable<SeedSearchResultDto>>
    {
        private readonly IRetreiveAllSeeds _seedsRetreiver;

        public SearchSeedQueryHandler(IRetreiveAllSeeds seedsRetreiver)
        {
            _seedsRetreiver = seedsRetreiver;
        }
        public IEnumerable<SeedSearchResultDto> Handle(SearchSeedQuery query)
        {
            return _seedsRetreiver
                .GetAll()
                .Where(s => s.Description.Contains(query.Keyword))
                .Select(s => new SeedSearchResultDto
                {
                    CategoryId = s.SeedCategoryId,
                    CategoryName = s.SeedCategory.Name,
                    Description = s.Description,
                    SeedId = s.Id
                });
        }
    }
}

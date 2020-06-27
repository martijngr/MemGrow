using Common.Cqs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemGrow.App.Domain.Seeding.GetSeeds
{
    public class GetSeedsRandomizedQuery : IQuery<IEnumerable<GetSeedDto>>
    {
    }

    public class GetSeedsRandomizedQueryHandler : IQueryHandler<GetSeedsRandomizedQuery, IEnumerable<GetSeedDto>>
    {
        private readonly IRetreiveAllSeeds _retreiveAllSeeds;

        public GetSeedsRandomizedQueryHandler(IRetreiveAllSeeds retreiveAllSeeds)
        {
            _retreiveAllSeeds = retreiveAllSeeds;
        }

        public IEnumerable<GetSeedDto> Handle(GetSeedsRandomizedQuery query)
        {
            var seeds = _retreiveAllSeeds.GetAll().ToList();
            var randomizedSeeds = seeds.OrderBy(s => Guid.NewGuid());

            return randomizedSeeds
                .Select(s => new GetSeedDto
                {
                    CategoryId = s.CategoryId,
                    Description = s.Description,
                    Id = s.Id
                })
                .ToList();
        }
    }
}
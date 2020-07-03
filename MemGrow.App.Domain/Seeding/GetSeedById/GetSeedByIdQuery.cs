using Common.Cqs;

namespace MemGrow.App.Domain.Seeding.GetSeedById
{
    public class GetSeedByIdQuery : IQuery<SeedDetailDto>
    {
        public int SeedId { get; set; }
    }

    public class GetSeedByIdQueryHandler : IQueryHandler<GetSeedByIdQuery, SeedDetailDto>
    {
        private readonly IGetSeedById _seedByIdGetter;

        public GetSeedByIdQueryHandler(IGetSeedById seedByIdGetter)
        {
            _seedByIdGetter = seedByIdGetter;
        }

        public SeedDetailDto Handle(GetSeedByIdQuery query)
        {
            var seed = _seedByIdGetter.GetById(query.SeedId);

            return new SeedDetailDto
            {
                CategoryId = seed.SeedCategoryId,
                Description = seed.Description,
                Id = seed.Id
            };
        }
    }
}

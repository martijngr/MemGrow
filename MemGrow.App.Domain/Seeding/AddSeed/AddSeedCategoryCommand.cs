using Common.Cqs;
using MemGrow.App.Domain.Seeding.AddSeedCategories;

namespace MemGrow.App.Domain.Seeding.AddSeed
{
    public class AddSeedCategoryCommand
    {
        public string Name { get; set; }
    }

    public class AddSeedCategoryCommandHandler : ICommandHandler<AddSeedCategoryCommand>
    {
        private readonly ISeedCategorySaver _seedCategorySaver;

        public AddSeedCategoryCommandHandler(ISeedCategorySaver seedCategorySaver)
        {
            _seedCategorySaver = seedCategorySaver;
        }

        public CommandResult Handle(AddSeedCategoryCommand command)
        {
            var category = CreateSeedCategory(command);

            _seedCategorySaver.Save(category);

            return CommandResult.Success(category.Id);
        }

        private SeedCategory CreateSeedCategory(AddSeedCategoryCommand command)
        {
            return new SeedCategory
            {
                Name = command.Name
            };
        }
    }
}

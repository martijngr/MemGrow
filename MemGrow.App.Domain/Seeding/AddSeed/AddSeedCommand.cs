using Common.Cqs;

namespace MemGrow.App.Domain.Seeding.AddSeed
{
    public class AddSeedCommand
    {
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }

    public class AddSeedCommandHandler : ICommandHandler<AddSeedCommand>
    {
        private readonly ISeedSaver _seedSaver;

        public AddSeedCommandHandler(ISeedSaver seedSaver)
        {
            _seedSaver = seedSaver;
        }

        public CommandResult Handle(AddSeedCommand command)
        {
            var seed = CreateSeed(command);
            _seedSaver.Save(seed);

            return CommandResult.Success(seed.Id);
        }

        private Seed CreateSeed(AddSeedCommand command)
        {
            return new Seed
            {
                Description = command.Description,
                CategoryId = command.CategoryId
            };
        }
    }
}

using Common.Cqs;

namespace MemGrow.App.Domain.Seeding.DeleteSeed
{
    public class DeleteSeedCommand
    {
        public int SeedId { get; set; }
    }

    public class DeleteSeedCommandHandler : ICommandHandler<DeleteSeedCommand>
    {
        private readonly IDeleteSeed _seedDeleter;

        public DeleteSeedCommandHandler(IDeleteSeed seedDeleter)
        {
            _seedDeleter = seedDeleter;
        }

        public CommandResult Handle(DeleteSeedCommand command)
        {
            _seedDeleter.DeleteSeed(command.SeedId);

            return CommandResult.Success();
        }
    }
}

using Common.Cqs;

namespace MemGrow.App.Domain.Seeding.EditSeed
{
    public class EditSeedCommand
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }
    }

    public class EditSeedCommandHandler : ICommandHandler<EditSeedCommand>
    {
        private readonly IEditSeed _seedEditor;

        public EditSeedCommandHandler(IEditSeed seedEditor)
        {
            _seedEditor = seedEditor;
        }

        public CommandResult Handle(EditSeedCommand command)
        {
            _seedEditor.EditSeed(new Seed
            {
                SeedCategoryId = command.CategoryId,
                Description = command.Description,
                Id = command.Id
            });

            return CommandResult.Success();
        }
    }
}

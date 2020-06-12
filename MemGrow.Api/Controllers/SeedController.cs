using Common.Cqs;
using MemGrow.App.Domain.Seeding.AddSeed;
using Microsoft.AspNetCore.Mvc;

namespace MemGrow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly CommandProcessor _commandProcessor;

        public SeedController(CommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public IActionResult Post(AddSeedCommand command)
        {
            var result = _commandProcessor.Handle(command);

            return Ok(result.Result);
        }
    }
}

using Common.Cqs;
using MemGrow.App.Domain.Seeding.AddSeed;
using MemGrow.App.Domain.Seeding.GetSeeds;
using Microsoft.AspNetCore.Mvc;

namespace MemGrow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly CommandProcessor _commandProcessor;
        private readonly QueryProcessor _queryProcessor;

        public SeedController(CommandProcessor commandProcessor, QueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        [HttpPost]
        public IActionResult Post(AddSeedCommand command)
        {
            var result = _commandProcessor.Handle(command);

            return Ok(result.Result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _queryProcessor.Handle(new GetSeedsRandomizedQuery());
            return Ok(result);
        }
    }
}

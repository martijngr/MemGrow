using Common.Cqs;
using MemGrow.App.Domain.Seeding.AddSeed;
using MemGrow.App.Domain.Seeding.DeleteSeed;
using MemGrow.App.Domain.Seeding.EditSeed;
using MemGrow.App.Domain.Seeding.GetSeedById;
using MemGrow.App.Domain.Seeding.GetSeeds;
using MemGrow.App.Domain.Seeding.Search;
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

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _queryProcessor.Handle(new GetSeedByIdQuery { SeedId = id });
            return Ok(result);
        }

        [HttpGet("Search/{keyword}")]
        public IActionResult Search(string keyword)
        {
            var result = _queryProcessor.Handle(new SearchSeedQuery { Keyword = keyword });
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(EditSeedCommand command)
        {
            var result = _commandProcessor.Handle(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _commandProcessor.Handle(new DeleteSeedCommand { SeedId = id});
            return Ok(result);
        }
    }
}

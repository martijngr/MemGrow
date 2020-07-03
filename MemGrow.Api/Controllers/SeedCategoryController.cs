using Common.Cqs;
using MemGrow.App.Domain.Seeding.AddSeed;
using MemGrow.App.Domain.Seeding.GetSeedCategories;
using Microsoft.AspNetCore.Mvc;

namespace MemGrow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedCategoryController : ControllerBase
    {
        private readonly CommandProcessor _commandProcessor;
        private readonly QueryProcessor _queryProcessor;

        public SeedCategoryController(CommandProcessor commandProcessor, QueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        [HttpPost]
        public IActionResult Post(AddSeedCategoryCommand command)
        {
            var result = _commandProcessor.Handle(command);

            return Ok(result.Result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_queryProcessor.Handle(new GetSeedCategoriesQuery()));
        }
    }
}
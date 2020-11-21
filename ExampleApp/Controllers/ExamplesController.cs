using System;
using System.Threading.Tasks;
using ExampleApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IExampleRepository exampleRepository;
        private readonly ILogger logger;

        public ExamplesController(IExampleRepository exampleRepository, ILogger<ExamplesController> logger)
        {
            this.exampleRepository = exampleRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var examples = await exampleRepository.GetAllAsync();
                return Ok(examples);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to get all Examples");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve examples");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var example = await exampleRepository.GetAsync(id);
                return Ok(example);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to get Example by Id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve examples");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Example example)
        {
            try
            {
                await exampleRepository.AddAsync(example);
                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to create Example");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve examples");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Example example)
        {
            try
            {
                await exampleRepository.UpdateAsync(example);
                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to udpate Example");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve examples");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var exampleToRemove = await exampleRepository.GetAsync(id);
                if(exampleToRemove != null)
                    await exampleRepository.DeleteAsync(exampleToRemove);
                return Ok();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Failed to delete Example");
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to retrieve examples");
            }
        }
    }
}

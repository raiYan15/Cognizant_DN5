using System.ComponentModel.DataAnnotations;
using FilterDemoApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomActionFilter))]
    public class DemoController : ControllerBase
    {
        // Hits the request-logging middleware + the CustomActionFilter (registered globally).
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");

        // Deliberately throws to demonstrate the CustomExceptionFilter.
        [HttpGet("boom")]
        public IActionResult Boom()
        {
            throw new InvalidOperationException("Something went wrong on purpose.");
        }

        // Requires a query param; missing/empty value triggers ModelState validation.
        [HttpGet("greet")]
        public IActionResult Greet([FromQuery][Required] string name)
        {
            return Ok($"Hello, {name}!");
        }
    }
}

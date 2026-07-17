using Microsoft.AspNetCore.Mvc;

namespace LoggingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private static readonly Dictionary<int, string> Orders = new()
        {
            { 1, "Laptop" },
            { 2, "Mouse" }
        };

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            _logger.LogInformation("Fetching order {OrderId}", id);

            if (!Orders.TryGetValue(id, out var item))
            {
                _logger.LogWarning("Order {OrderId} not found", id);
                throw new KeyNotFoundException($"Order with id {id} was not found.");
            }

            return Ok(new { id, item });
        }

        [HttpGet("invalid-demo")]
        public IActionResult InvalidDemo()
        {
            throw new ArgumentException("Demo: invalid argument supplied.");
        }

        [HttpGet("server-error-demo")]
        public IActionResult ServerErrorDemo()
        {
            throw new Exception("Demo: unexpected server error.");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace ApiKeySecurityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowFrontend")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecureData()
        {
            return Ok(new
            {
                message = "This endpoint is protected by an API key and reachable via CORS from the allowed origin.",
                timestamp = DateTime.UtcNow
            });
        }
    }
}

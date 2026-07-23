using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]

        [Authorize]

        public IActionResult GetSecureData()
        {
            return Ok("This is protected data.");
        }
    }
}
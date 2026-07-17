using JwtAuthWebApi.Helpers;
using JwtAuthWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        // Hardcoded demo users. In a real app this would query a database with hashed passwords.
        private static readonly List<AppUser> Users = new()
        {
            new AppUser { Username = "admin", Password = "Admin@123", Role = "Admin" },
            new AppUser { Username = "sadwik", Password = "User@123", Role = "User" }
        };

        public AuthController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var user = Users.FirstOrDefault(u =>
                u.Username == request.Username && u.Password == request.Password);

            if (user is null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var (token, expiresAtUtc) = _tokenGenerator.GenerateToken(user.Username, user.Role);

            return Ok(new LoginResponse { Token = token, ExpiresAtUtc = expiresAtUtc });
        }
    }
}

using JwtAuth.Services;
using JwtAuth.Models;
using JwtAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // In real-world applications, you would validate the user credentials with a database.
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _tokenService.GenerateToken(request.Username, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}

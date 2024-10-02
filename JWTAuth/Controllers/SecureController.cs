using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("This is an Admin-protected endpoint.");
        }

        [HttpGet("user")]
        [Authorize]
        public IActionResult UserEndpoint()
        {
            return Ok("This is a User-protected endpoint.");
        }
    }
}

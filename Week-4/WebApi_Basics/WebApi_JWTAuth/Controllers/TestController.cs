using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_JWTAuth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public() => Ok("Public endpoint");

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin() => Ok("Admin-only endpoint");

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult UserOnly() => Ok("User-only endpoint");

        [HttpGet("any")]
        [Authorize]
        public IActionResult AnyAuthenticated() => Ok("Any authenticated user");
    }
}
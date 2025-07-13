using Microsoft.AspNetCore.Mvc;

namespace WebApi_Versioning.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/values")]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("This is v1");
    }
}
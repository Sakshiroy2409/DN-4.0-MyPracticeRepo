using Microsoft.AspNetCore.Mvc;

namespace WebApi_Versioning.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/values")]
    public class ValuesV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("This is v2");
    }
}
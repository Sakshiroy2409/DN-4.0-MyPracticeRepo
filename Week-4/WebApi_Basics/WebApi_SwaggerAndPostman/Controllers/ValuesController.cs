using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_SwaggerAndPostman.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> data = new List<string> { "Value1", "Value2" };

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(data);
        }

        // GET: api/values/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= data.Count)
                return NotFound("Item not found");

            return Ok(data[id]);
        }

        // POST: api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Post([FromBody] string value)
        {
            data.Add(value);
            return Ok("Value added successfully");
        }

        // PUT: api/values/1
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= data.Count)
                return NotFound("Item not found");

            data[id] = value;
            return Ok("Value updated successfully");
        }

        // DELETE: api/values/1
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= data.Count)
                return NotFound("Item not found");

            data.RemoveAt(id);
            return Ok("Value deleted successfully");
        }

        // GET: api/values/getall (custom route name)
        [HttpGet("getall", Name = "GetAllValues")]
        public ActionResult<IEnumerable<string>> GetAllCustom()
        {
            return Ok(data);
        }
    }
}
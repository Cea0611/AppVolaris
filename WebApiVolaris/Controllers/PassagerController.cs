using Microsoft.AspNetCore.Mvc;
using WebApiVolaris.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PassagerController.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassagerController : ControllerBase
    {
        // GET: api/<PassagerController>
        [HttpGet]
        public ApiResponse Get()
        {
            return new FlightModel().GetAll();
        }

        // GET api/<PassagerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PassagerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PassagerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PassagerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
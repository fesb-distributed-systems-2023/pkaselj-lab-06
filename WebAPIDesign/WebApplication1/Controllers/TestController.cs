using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("/temperature")]
        public IActionResult GetTemperature()
        {
            return Ok(3.14);
        }

        [HttpGet]
        [Route("/hello/{name}")]
        public IActionResult GetTemperature2([FromRoute]string name)
        {
            return Ok($"Hello, {name}");
        }

        [HttpGet]
        [Route("/hello")]
        public IActionResult GetTemperature3([FromQuery]string name, [FromQuery]string surname)
        {
            return Ok($"Hello, {name} {surname}");
        }

        [HttpPost]
        [Route("/hellofrombody")]
        public IActionResult PostTemperature([FromBody]string name)
        {
            return Ok($"Hello, {name}");
        }
    }
}

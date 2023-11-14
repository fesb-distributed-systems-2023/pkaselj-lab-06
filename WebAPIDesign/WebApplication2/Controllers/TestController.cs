using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAPIDesign.ObjectTransfer.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("/hello/{name}")]
        public IActionResult GetHello([FromRoute] string name)
        {
            return Ok($"Hello, {name}");
        }

        [HttpGet]
        [Route("/hello")]
        public IActionResult GetHello2([FromQuery] string name)
        {
            return Ok($"Hello, {name}");
        }

        [HttpPost]
        [Route("/hello")]
        public IActionResult GetHello3([FromBody] string name)
        {
            return Ok($"Hello, {name}");
        }

        [HttpGet]
        [Route("/mail/{sender}/{recipient}/{subject}/{message}")]
        public IActionResult GetMaiil(string sender, string recipient, string subject, string message)
        {
            Email email = new Email
            {
                Sender = sender,
                Recipient = recipient,
                Subject = subject,
                Message = message
            };
            return Ok();
        }

    }
}

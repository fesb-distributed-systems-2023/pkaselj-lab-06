/*
 **********************************
 * Author: Petar Kaselj
 * Project Task: Object Transfer
 **********************************
 * Description:
 *  A program that demonstrates passing 
 *  complex objects to the web api
 **********************************
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDesign.ObjectTransfer.Models;

namespace WebAPIDesign.ObjectTransfer.Controllers
{
    [ApiController]
    public class ComplexObjectController : ControllerBase
    {
        // Sending complex parameters by route is not possible !!!


        /* 
         * 
         * Sending a complex parameter using query.
         * Postman example:
         * GET http://localhost:5243/send?sender=petar&recipient=mijo&subject=homework&message=do%20your%20homework
         * See for more information: https://en.wikipedia.org/wiki/Percent-encoding
         * 
         */
        [HttpGet("/send")]
        public IActionResult SendEmailByQuery([FromQuery] Email email)
        {
            string response = $"Sending mail from {email.Sender} to {email.Recipient}"
                + $" with subject '{email.Subject}' and body: '{email.Message}'";

            return Ok($"Query :: {response}");
        }

        /* 
         * 
         * Sending a complex parameter in body.
         * Postman example:
         *      POST http://localhost:5243/send
         *      Headers:
         *          Content-Type: application/json
         *      Body:
         *          {
         *              "sender" : "petar",
         *              "recipient" : "mijo",
         *              "subject" : "homework",
         *              "message" : "do your homework"
         *          }
         *          
         * See for more information: https://www.javatpoint.com/json-example
         * 
         */
        [HttpPost("/send")]
        public IActionResult SendEmailInBody([FromBody] Email email)
        {
            string response = $"Sending mail from {email.Sender} to {email.Recipient}"
                + $" with subject '{email.Subject}' and body: '{email.Message}'";

            return Ok($"Body :: {response}");
        }
    }
}

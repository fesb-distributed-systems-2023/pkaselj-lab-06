/*
 **********************************
 * Author: Petar Kaselj
 * Project Task: Collection Transfer
 **********************************
 * Description:
 *  A program that demonstrates passing 
 *  collections to the web api
 **********************************
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDesign.ObjectTransfer.Models;

namespace WebAPIDesign.ObjectTransfer.Controllers
{
    [ApiController]
    public class CollectionController : ControllerBase
    {
        // Sending collections by route is not possible !!!


        /* 
         * 
         * Sending a simple collection of numbers using query.
         * Postman example:
         *  GET http://localhost:5243/collection/simple?numbers=13&numbers=21&numbers=33
         * 
         */
        [HttpGet("/collection/simple")]
        public IActionResult SendSimpleCollectionByQuery([FromQuery] IEnumerable<int> numbers)
        {
            string response = "";

            foreach (int number in numbers)
            {
                response += $"{number}, ";
            }

            return Ok($"Query :: {response}");
        }

        /* 
         * 
         * Sending a simple collection of numbers in body.
         * Postman example:
         *  POST http://localhost:5243/collection/simple
         * Headers:
         *  Content-Type: application/json
         * Body:
         *  [1, 2, 33, 4, -2, 3]
         * 
         */
        [HttpPost("/collection/simple")]
        public IActionResult SendSimpleCollectionInBody([FromBody] IEnumerable<int> numbers)
        {
            string response = "";

            foreach (int number in numbers)
            {
                response += $"{number}, ";
            }

            return Ok($"Body :: {response}");
        }

        /* 
         * 
         * Sending a collection of complex objects using query.
         * Postman example:
         * 
         * GET http://localhost:5243/collection/emails
         *      ?[0].sender=petar&[0].recipient=mijo(...)
         *      &[0].subject=homework&[0].message=do%20your%20homework(...)
         *      &[1].sender=mijo&[1].recipient=petar(...)
         *      &[1].subject=homework&[1].message=no
         *      
         * or (don't do this manually):
         * 
         * GET http://localhost:5027/collection/emails(...)
         *      ?emails=%7B%0A%20%20%22sender%22%3A%20(...)
         *      %22petar%22%2C%0A%20%20%22recipient%22(...)
         *      %3A%20%22mijo%22%2C%0A%20%20%22subject(...)
         *      %22%3A%20%22homework%22%2C%0A%20%20%22(...)
         *      message%22%3A%20%22Do%20your%20homework(...)
         *      %22%0A%7D&emails=%7B%0A%20%20%22sender(...)
         *      %22%3A%20%22mijo%22%2C%0A%20%20%22recipient(...)
         *      %22%3A%20%22petar%22%2C%0A%20%20%22subject(...)
         *      %22%3A%20%22homework%22%2C%0A%20%20%22(...)
         *      message%22%3A%20%22No%22%0A%7D
         * 
         */
        [HttpGet("/collection/emails")]
        public IActionResult SendEmailByQuery([FromQuery] IEnumerable<Email> emails)
        {
            string response = "";

            foreach (var email in emails)
            {
                response += $"Sending mail from {email.Sender} to {email.Recipient}"
                         + $" with subject '{email.Subject}' and body: '{email.Message}'"
                         + "\n";
            }


            return Ok($"Query :: {response}");
        }

        /* 
         * 
         * Sending a collection of complex objects in body.
         * Postman example:
         *  POST http://localhost:5243/collection/emails
         * Headers:
         *  Content-Type: application/json
         * Body:
         *  [
         *      {
         *          "sender": "petar",
         *          "recipient": "mijo",
         *          "subject": "homework",
         *          "message": "Do your homework"
         *      },
         *      {
         *          "sender": "mijo",
         *          "recipient": "petar",
         *          "subject": "homework",
         *          "message": "No"
         *      }
         *  ]
         * 
         */
        [HttpPost("/collection/emails")]
        public IActionResult SendEmailInBody([FromBody] IEnumerable<Email> emails)
        {
            string response = "";

            foreach (var email in emails)
            {
                response += $"Sending mail from {email.Sender} to {email.Recipient}"
                         + $" with subject '{email.Subject}' and body: '{email.Message}'"
                         + "\n";
            }


            return Ok($"Query :: {response}");
        }
    }
}

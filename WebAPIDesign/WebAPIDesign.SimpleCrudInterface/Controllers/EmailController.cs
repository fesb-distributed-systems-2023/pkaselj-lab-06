/*
 **********************************
 * Author: Petar Kaselj
 * Project Task: Simple Email CRUD Interface
 **********************************
 * Description:
 *  A program that demonstrates a simple CRUD interface.
 *  The program stores a list of emails and provides the user
 *  with an API to execute Create-Read-Update-Delete (CRUD) operations:
 *      - Create - Add new emails
 *      - Read - Get an email
 *      - Update - Edit specific email info
 *      - Delete - Delete an email
 **********************************
 */

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDesign.SimpleCrudInterface.Models;
using WebAPIDesign.SimpleCrudInterface.Repositories;

namespace WebAPIDesign.SimpleCrudInterface.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        // Handles all emails.
        /* 
         * IMPORTANT: See `Program.cs`
         *  All controllers are Transient - meaning
         *  they are constructed and deleted per each HTTP request.
         *  
         *  To keep (persist) the data between multiple requests,
         *  the data must be extracted to a class (EmailRepository)
         *  which will be shared by multiple controllers i.e.
         *  it will be registered not as Transient but Singleton in `Program.cs`.
         *  
         *  This pattern is called Dependency Injection.
         *  
         *  See https://www.c-sharpcorner.com/article/differences-between-scoped-transient-and-singleton-service/
         *  See https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0
         */
        private readonly EmailRepository m_emailRepository;

        // Use dependency injection to inject an instance of `EmailRepository`
        public EmailController(EmailRepository emailRepository)
        {
            m_emailRepository = emailRepository;
        }

        /*
         * Create Operation: Create an email object
         */
        [HttpPost("/mails/new")]
        public IActionResult PostNewEmail([FromBody] Email email)
        {
            bool fSuccess = m_emailRepository.CreateNewEmail(email);

            if(fSuccess)
            {
                return Ok("Email succesfully created!");
            }
            else
            {
                return BadRequest("Error while creating an email!");
            }
        }

        /*
         * Read Operation 1 - Get all emails
         */
        [HttpGet("/mails/all")]
        public IActionResult GetAllEmails()
        {
            return Ok(m_emailRepository.GetAllEmails());
        }

        /*
         * Read Operation 2 - Get the email with the specified ID
         */
        [HttpGet("/mails/{id}")]
        public IActionResult GetEmailById([FromRoute]int id)
        {
            var email = m_emailRepository.GetEmail(id);

            if(email is null)
            {
                return NotFound($"Could not find an email with ID = {id}");
            }
            else
            {
                return Ok(email);
            }
        }

        /*
         * Delete Operation - Delete the email with the specified ID
         */
        [HttpDelete("/mails/{id}")]
        public IActionResult DeleteEmailById([FromRoute] int id)
        {
            if(m_emailRepository.DeleteEmail(id))
            {
                return Ok($"Succesfully deleted the email with ID = {id}");
            }
            else
            {
                return NotFound($"Could not find an email with ID = {id}");
            }
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using WebAPIDesign.SimpleCrudInterface.Models;
using WebAPIDesign.SimpleCrudInterface.Repositories.Interfaces;

namespace WebAPIDesign.SimpleCrudInterface.Repositories
{
    // Implement the `IEmailRepository` interface
    public class EmailRepository : IEmailRepository
    {
        // A list of all emails
        private List<Email> m_lstEmail;
        private object m_oLock = new object();

        public EmailRepository()
        {
            // Create and initialize a new email list
            // at the beginning*
            m_lstEmail = new List<Email>();
        }

        // Generate a random unique id for a new email
        private int GenerateUniqueId()
        {
            int generatedId;

            // Prevent any other thread/request from accessing the list
            // during ID generation, so the ID is guaranteed to be unique
            lock (m_oLock)
            {
                do
                {
                    // Pick a random number
                    generatedId = Random.Shared.Next(0, 1024);
                }
                while (m_lstEmail.Any(email => email.Id == generatedId));
            }

            return generatedId;
        }

        // Generate a string representation of
        // current time in yyyy-MM-dd HH:mm:ss.fff format
        private string GetCurrentTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /*
         * Create Operation: Create an email object
         */
        public bool CreateNewEmail(Email email)
        {
            // Generate a new ID for the email.
            // Ignore what the user provided
            email.Id = GenerateUniqueId();

            // Generate a new timestamo for the email
            // Ignore what the user provided
            email.Timestamp = GetCurrentTimestamp();

            lock (m_oLock)
            {
                // Add the new email to the list
                m_lstEmail.Add(email);
            }

            // Always succeeds
            return true;
        }

        /*
         * Read Operation 1 - Get all emails
         */
        public IEnumerable<Email> GetAllEmails()
        {
            return m_lstEmail;
        }

        /*
         * Read Operation 2 - Get the email with the specified ID
         *  If the email doesn't exist return null.
         */
        public Email GetEmail(int id)
        {
            // Check if any email matches the given id
            if (!m_lstEmail.Any(email => email.Id == id))
            {
                // If not, return null
                return null;
            }

            // If an email matches an id, return that email object
            var email = m_lstEmail.FirstOrDefault(email => email.Id == id);

            // Return the email
            return email;
        }

        /*
         * Update Operation - Update the email with the specified ID
         *  Return true on success or false on failure
         */
        public bool UpdateEmail(int id, Email newEmail)
        {
            // Check if any email matches the given id (from route, ignore body)
            if (!m_lstEmail.Any(email => email.Id == id))
            {
                // If not, return false
                return false;
            }

            lock (m_oLock)
            {
                // If an email matches an id, update the email information
                var refEmail = m_lstEmail.FirstOrDefault(x => x.Id == id);

                // Do not change the ID
                // refEmail.Id = newEmail.Id;
                refEmail.Sender = newEmail.Sender;
                refEmail.Recipient = newEmail.Recipient;
                refEmail.Subject = newEmail.Subject;
                refEmail.Message = newEmail.Message;
                refEmail.Timestamp = newEmail.Timestamp;
            }

            // Return true on success
            return true;
        }

        /*
         * Delete Operation - Delete the email with the specified ID
         *  Return true on success or false on failure
         */
        public bool DeleteEmail(int id)
        {
            // Check if any email matches the given id
            if (!m_lstEmail.Any(email => email.Id == id))
            {
                // If not, return false
                return false;
            }

            lock (m_oLock)
            {
                // If an email matches an id, delete
                m_lstEmail = m_lstEmail.Where(x => x.Id != id).ToList();
            }

            // Return true on success
            return true;
        }


    }
}

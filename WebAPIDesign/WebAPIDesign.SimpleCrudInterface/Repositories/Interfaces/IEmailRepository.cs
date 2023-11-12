using WebAPIDesign.SimpleCrudInterface.Models;

namespace WebAPIDesign.SimpleCrudInterface.Repositories.Interfaces
{
    public interface IEmailRepository
    {
        /*
         * Create Operation: Create an email object
         */
        public bool CreateNewEmail(Email email);

        /*
         * Read Operation 1 - Get all emails
         */
        public IEnumerable<Email> GetAllEmails();

        /*
         * Read Operation 2 - Get the email with the specified ID
         *  If the email doesn't exist return null.
         */
        public Email GetEmail(int id);

        /*
         * Update Operation - Update the email with the specified ID
         *  Return true on success or false on failure
         */
        public bool UpdateEmail(int id, Email newEmail);

        /*
         * Delete Operation - Delete the email with the specified ID
         *  Return true on success or false on failure
         */
        public bool DeleteEmail(int id);
    }
}

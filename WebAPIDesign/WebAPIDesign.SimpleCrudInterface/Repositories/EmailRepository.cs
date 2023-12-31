﻿using Microsoft.AspNetCore.Mvc;
using WebAPIDesign.SimpleCrudInterface.Models;
using WebAPIDesign.SimpleCrudInterface.Repositories;

namespace WebAPIDesign.SimpleCrudInterface.Repositories
{
    // Implement the `IEmailRepository` interface
    public class EmailRepository
    {
        // A list of all emails
        private List<Email> m_lstEmail;

        // ctor + tab
        public EmailRepository()
        {
            // Create and initialize a new email list
            // at the beginning*
            m_lstEmail = new List<Email>();
        }

        /*
         * Create Operation: Create an email object
         */
        public bool CreateNewEmail(Email email)
        {
            // Add the new email to the list
            m_lstEmail.Add(email);

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
         * Delete Operation - Delete the email with the specified ID
         *  Return true on success or false on failure
         */
        public bool DeleteEmail(int id)
        {
            // Check if any email matches the given id
            var itemToDelete = m_lstEmail.FirstOrDefault(itemEmail => itemEmail.Id == id);
            if (itemToDelete == null)
            {
                // If not, return false
                return false;
            }

            m_lstEmail.Remove(itemToDelete);

            // Return true on success
            return true;
        }


    }
}

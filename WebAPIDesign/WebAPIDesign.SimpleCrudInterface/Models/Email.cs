namespace WebAPIDesign.SimpleCrudInterface.Models
{
    public class Email
    {
        // prop + tab
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
 
    }
}

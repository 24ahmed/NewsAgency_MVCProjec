using System.ComponentModel.DataAnnotations.Schema;

namespace News_Project.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        public int phone { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }

    }
}

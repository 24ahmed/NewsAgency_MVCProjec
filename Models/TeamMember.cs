using System.ComponentModel.DataAnnotations.Schema;

namespace News_Project.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string JobTitle { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace News_Project.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string? ImgUrl { get; set; }
        public string Topic { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
    }
}

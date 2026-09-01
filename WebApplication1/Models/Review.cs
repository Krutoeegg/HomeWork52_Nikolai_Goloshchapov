using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public int Rating { get; set; }
        public int? PhoneId { get; set; }
        public Phone? Phone { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ForumV2.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Content { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace ForumV2.ViewModels
{
    public class AddPostViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; } = null!;
        
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Content { get; set; } = null!;

    }
}

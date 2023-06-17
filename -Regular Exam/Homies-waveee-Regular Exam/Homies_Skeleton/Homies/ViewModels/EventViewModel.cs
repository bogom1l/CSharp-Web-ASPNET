using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        public string Organiser { get; set; } = null!;
    }
}

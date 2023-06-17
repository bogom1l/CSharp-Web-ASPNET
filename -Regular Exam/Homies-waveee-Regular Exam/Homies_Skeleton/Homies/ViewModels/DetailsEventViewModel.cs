using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class DetailsEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public string Organiser { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        public string Type { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class AddEventViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required] 
        public string Start { get; set; } = null!;
        
        [Required]
        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace Homies.ViewModels
{
    public class TypeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using static Library.GlobalConstants.GlobalConstants.CategoryConstants;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } 

        [MaxLength(CategoryNameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}

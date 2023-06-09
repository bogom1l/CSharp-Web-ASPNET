using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Required]
        public string CollectorId { get; set; } = null!;

        public IdentityUser Collector { get; set; }

        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class ContactViewModel
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Required]
        public string Website { get; set; } = null!;

        public int Action { get; set; }

    }
}

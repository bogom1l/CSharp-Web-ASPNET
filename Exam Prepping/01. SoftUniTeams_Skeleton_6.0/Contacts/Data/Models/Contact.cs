using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(50)] public string FirstName { get; set; } = null!;

        [Required] [MaxLength(50)] public string LastName { get; set; } = null!;

        [Required] [MaxLength(60)] public string Email { get; set; } = null!;

        [Required] [MaxLength(13)] public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        [Required] public string Website { get; set; } = null!;

        public ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; } =
            new List<ApplicationUserContact>();
    }
}

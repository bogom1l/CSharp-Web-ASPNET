using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserContact> ApplicationUserContacts { get; set; } =
            new List<ApplicationUserContact>();
    }
}
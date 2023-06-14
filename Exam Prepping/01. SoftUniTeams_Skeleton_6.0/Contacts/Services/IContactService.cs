using Contacts.Models;
using Microsoft.Build.ObjectModelRemoting;

namespace Contacts.Services
{
    public interface IContactService
    {
        Task<ICollection<ContactViewModel>> GetAllContacts();

        Task AddContactAsync(ContactViewModel contact);

        Task<ContactViewModel> FindContactAsync(int id);

        Task EditContactAsync(int id, ContactViewModel contact);

        Task<IEnumerable<ContactViewModel>> GetAllTeamsAsync(string userId);

        Task AddTeamAsync(int id, string userId);
        Task RemoveFromTeamAsync(int id, string userId);
    }
}

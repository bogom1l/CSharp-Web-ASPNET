using Contacts.Models;

namespace Contacts.Services
{
    public interface IContactService
    {
        Task<ICollection<ContactViewModel>> GetAllContacts();

        Task AddContactAsync(ContactViewModel contact);

        Task<ContactViewModel> FindContactAsync(int id);

        Task EditContactAsync(int id, ContactViewModel contact);
    }
}

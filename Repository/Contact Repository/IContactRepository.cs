using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Contact_Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact?> GetContactById(int contactId);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(int contactId,Contact contact);
        Task<Contact?> DeleteContact(int contactId);

    }
}

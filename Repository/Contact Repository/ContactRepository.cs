using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Contact_Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BookDbContext context;

        public ContactRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Contact> AddContact(Contact contact)
        {
            try
            {
                if (contact != null)
                {
                    await context.Contacts.AddAsync(contact);
                    await context.SaveChangesAsync();
                    return contact;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact?> DeleteContact(int contactId)
        {

            try
            {
                var contact = await context.Contacts.FirstOrDefaultAsync(a => a.ContactId == contactId);
                if (contact == null)
                {
                    return null;
                }
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();
                return contact;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Task<List<Contact>> GetAllContacts()
        {
            return context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetContactById(int contactId)
        {
            try
            {
                var contact = await context.Contacts.FirstOrDefaultAsync(a => a.ContactId == contactId);
                if (contact == null)
                {
                    return null;
                }
                return contact;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> UpdateContact(int contactId, Contact contact)
        {
            try
            {
                var resContact = await context.Contacts.FirstOrDefaultAsync(a => a.ContactId == contactId);
                if (resContact == null)
                {
                    return null;
                }
                resContact.ContactName= contact.ContactName;
                resContact.PhoneNo= contact.PhoneNo;
                resContact.Email= contact.Email;
                resContact.AddressLine1 = contact.AddressLine1;
                resContact.AddressLine2= contact.AddressLine2;
                resContact.City = contact.City;
                resContact.State= contact.State;
                resContact.Country= contact.Country;

                await context.SaveChangesAsync();
                return resContact;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

using System.Collections.Generic;
using PhoneBook.Domain.Model;

namespace PhoneBook.ServicePlatform.ExternalContracts
{
    public interface IContactService
    {
        int CreateContact(Contact contact);
        Contact SelectContactById(int contactId);
        IEnumerable<Contact> SelectAllContact();
        void EditContact(Contact contact);
        void DeleteContact(int contactId);
    }
}

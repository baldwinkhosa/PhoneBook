using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Data.Infrastructure;
using PhoneBook.Domain.Model;
using PhoneBook.ServicePlatform.ExternalContracts;

namespace PhoneBook.BusinessLibrary.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int CreateContact(Contact contact)
        {
            _unitOfWork.ContactRepository.Insert(contact);
            SaveChanges();
            return contact.ContactId;
        }

        public Contact SelectContactById(int contactId)
        {
            return _unitOfWork.ContactRepository.Single(contactId);
        }

        public IEnumerable<Contact> SelectAllContact()
        {
            return _unitOfWork.ContactRepository.GetAll();
        }

        public void EditContact(Contact contact)
        {
            _unitOfWork.ContactRepository.Update(contact);
            SaveChanges();
        }

        public void DeleteContact(int contactId)
        {
            Contact contact = SelectContactById(contactId);
            _unitOfWork.ContactRepository.Delete(contact);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }

}

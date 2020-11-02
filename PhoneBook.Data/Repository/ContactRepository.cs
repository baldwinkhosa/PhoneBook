using PhoneBook.Data.Infrastructure;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}

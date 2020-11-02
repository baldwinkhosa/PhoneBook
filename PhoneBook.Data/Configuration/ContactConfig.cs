using System.Data.Entity.ModelConfiguration;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Configuration
{
    public class ContactConfig : EntityTypeConfiguration<Contact>
    {
        public ContactConfig()
        {

        }
    }
}

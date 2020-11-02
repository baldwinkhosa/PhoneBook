
using System.Data.Entity.ModelConfiguration;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Configuration
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasMany(u => u.Contacts).WithOptional().HasForeignKey(u => u.UserId);
        }
    }
}

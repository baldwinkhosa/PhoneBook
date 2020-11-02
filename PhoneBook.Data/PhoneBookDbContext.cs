
using System.Data.Entity;
using PhoneBook.Data.Configuration;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext()
         : base("PhoneBook")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PhoneBookDbContext>());
        }

        public DbSet<User> Users;
        public DbSet<Contact> Contacts;
        public DbSet<ContactDetail> ContactDetails;
        public DbSet<Captcha> CaptchaQuestions;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Configurations.Add(new CaptchaConfig());

        }
    }
}


using PhoneBook.Data.Infrastructure;

namespace PhoneBook.Data.Repository
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private PhoneBookDbContext _dbContext;
        public PhoneBookDbContext GetDbContext()
        {
            return _dbContext ?? (_dbContext = new PhoneBookDbContext());
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}

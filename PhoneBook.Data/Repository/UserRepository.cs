using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Data.Infrastructure;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }
        public User GetUserFromUserName(Expression<Func<User, bool>> where)
        {
            return DbContext.Set<User>().Single(where);
        }
    }
}

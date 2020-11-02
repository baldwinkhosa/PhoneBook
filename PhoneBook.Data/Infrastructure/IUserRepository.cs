using System;
using System.Linq.Expressions;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Infrastructure
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserFromUserName(Expression<Func<User, bool>> where);
    }
}

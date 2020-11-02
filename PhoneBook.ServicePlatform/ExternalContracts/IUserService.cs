using System.Collections.Generic;
using PhoneBook.Domain.Model;

namespace PhoneBook.ServicePlatform.ExternalContracts
{
    public interface IUserService
    {
        User SelectUserById(int userId);
        IEnumerable<User> SelectAllUsers();
        int CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User Exists(User user);
    }
}

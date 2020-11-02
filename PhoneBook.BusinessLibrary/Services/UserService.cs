using PhoneBook.ServicePlatform.ExternalContracts;
using PhoneBook.Domain.Model;
using System.Collections.Generic;
using PhoneBook.Data.Infrastructure;

namespace PhoneBook.BusinessLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User SelectUserById(int userId)
        {
            return _unitOfWork.UserRepository.Single(userId);
        }

        public IEnumerable<User> SelectAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public int CreateUser(User user)
        {
            bool userExists = _unitOfWork.UserRepository.Exists(u => u.UserName == user.UserName);
            if (userExists) return 0;
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Commit();
            return user.UserId;
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteUser(int userId)
        {
            _unitOfWork.UserRepository.Delete(SelectUserById(userId));
        }

        public User Exists(User user)
        {
            bool validUser = _unitOfWork.UserRepository.Exists(u => u.UserName == user.UserName && u.Password == user.Password);
            return validUser ? _unitOfWork.UserRepository.GetUserFromUserName(u => u.UserName == user.UserName) : null;
        }
    }
}

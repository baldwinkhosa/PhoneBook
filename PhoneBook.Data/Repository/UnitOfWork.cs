using PhoneBook.Data.Infrastructure;

namespace PhoneBook.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PhoneBookDbContext _dbContext;
        private readonly IDatabaseFactory _databaseFactory;
        private IUserRepository _userRepository;
        private ICaptchaRepository _captchaRepository;
        private IContactRepository _contactRepository;
        public PhoneBookDbContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _databaseFactory.GetDbContext());
            }
        }
        public UnitOfWork(IDatabaseFactory databaseFactory) => _databaseFactory = databaseFactory;
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_databaseFactory));
            }
        }

        public ICaptchaRepository CaptchaRepository
        {
            get
            {
                return _captchaRepository ?? (_captchaRepository = new CaptchaRepository(_databaseFactory));
            }
        }


        public IContactRepository ContactRepository
        {
            get { return _contactRepository ?? (_contactRepository = new ContactRepository(_databaseFactory)); }
        }
    }
}

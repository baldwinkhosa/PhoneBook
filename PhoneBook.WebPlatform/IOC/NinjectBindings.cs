
using Ninject.Modules;
using PhoneBook.BusinessLibrary.Services;
using PhoneBook.Data.Infrastructure;
using PhoneBook.Data.Repository;
using PhoneBook.ServicePlatform.ExternalContracts;

namespace PhoneBook.WebPlatform.IOC
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseFactory>().To<DatabaseFactory>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserService>().To<UserService>();
            Bind<ICaptchaService>().To<CaptchaService>();
            Bind<IContactService>().To<ContactService>();
        }
    }
}
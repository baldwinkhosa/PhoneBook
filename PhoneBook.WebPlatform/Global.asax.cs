using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using PhoneBook.WebPlatform.App_Start;
using PhoneBook.WebPlatform.IOC;

namespace PhoneBook.WebPlatform
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new NinjectBindings());
            return kernel;
        }
    }
    
}

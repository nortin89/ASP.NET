using Porfolio.App_Start;
using Porfolio.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Porfolio
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);

      RouteConfig.RegisterRoutes(RouteTable.Routes);
      Database.SetInitializer<PortfolioDatabase>(null);
    }
  }
}

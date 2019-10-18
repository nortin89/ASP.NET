using System.Web.Mvc;
using System.Web.Routing;

namespace Porfolio
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      //routes.MapRoute(
      //  name: null,
      //  url: "",
      //  defaults: new { controller = "Account", action = "Login" });


      routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}

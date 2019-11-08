using FluentScheduler;
using Newsletter.Jobs;
using Newsletter.Models;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace Newsletter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<NewsletterDatabase>(null);

            JobManager.Initialize(new JobRegistry());
        }
    }
}

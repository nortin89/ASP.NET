using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SportsStore.Models;
using SportsStore.Infrastructure.Binders;
using System.Data.Entity;

namespace SportsStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<SportsStoreDatabase>(null);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder()); //p.229
        }
    }
}

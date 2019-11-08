using FluentScheduler;
using PartyInvites.Jobs;
using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PartyInvites
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // disable migrations
            Database.SetInitializer<PartyInviteDatabase>(null);

            // let the JobManager know about our registry
            JobManager.Initialize(new JobRegistry());
        }
    }
}

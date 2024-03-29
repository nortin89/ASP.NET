﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(name: null, url: "", defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 });

      routes.MapRoute(name: null, url: "Admin", defaults: new { controller = "Admin", action = "Index" });

      routes.MapRoute(
        name: null,
        url: "Page{page}",
        defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 }, constraints: new { page = @"\d+" }
        );

      routes.MapRoute(name: null, url: "{category}", defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 });

      routes.MapRoute(name: null, url: "{category}/Page{page}", defaults: new { controller = "Product", action = "List", categor = (string)null, page = 1 }, constraints: new { page = @"\d+" });

      routes.MapRoute(null, "{controller}/{action}");

      //p.202-203
      //routes.MapRoute(
      //    name: "Default",
      //    url: "{controller}/{action}/{id}",
      //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
      //);
    }
  }
}

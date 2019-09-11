using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
  public class NavController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();
    // GET: Nav
    public PartialViewResult Menu()
    {
      List<string> categoryNames = _db.Products
        .Select(x => x.Category)
        .OrderBy(x => x)
        .Distinct()
        .ToList();
      return PartialView(categoryNames);
    }
  }
}
using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      var products = new List<Product> {
        new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
        new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
        new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
        new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
      };

      // TODO: Find the three highest priced products
      // and pass them to the view

      //products.Sort((x, y) => {
      //  if (x.Price > y.Price) return -1;
      //  if (x.Price < y.Price) return 1;
      //  return 0;
      //});

      //var topProducts = new List<Product>();
      //for (int i = 0; i < 3 && i < products.Count; ++i)
      //{
      //  topProducts.Add(products[i]);
      //}

      //var topProducts =
      //  products.OrderByDescending(x => x.Price)
      //          .Take(3)
      //          .ToList();

      var topProducts = products.Where(x => x.Category == "Soccer");

      return View(topProducts);
    }
  }
}
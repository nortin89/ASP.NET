using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
  public class CartController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    private Cart GetCart()
    {
      Cart cart = Session["Cart"] as Cart;
      if (cart == null)
      {
        cart = new Cart();
        Session["Cart"] = cart;
      }
      return cart;
    }

    // GET: Cart
    public ActionResult Index(string returnUrl)
    {
      ViewBag.returnUrl = returnUrl;

      return View(GetCart());
    }

    [HttpPost]
    public ActionResult AddToCart(int productId,string returnUrl)
    {
      //Find, Single, First, Last
      //FirstOrDefault, SingleOrDefault, LastOrDefault

      Product product = _db.Products.SingleOrDefault(x => x.ProductID == productId);
      if(product != null)
      {
        GetCart().Add(product, 1);
      }
      return RedirectToAction("Index", routeValues: new { returnUrl });

    }

    [HttpPost]
    public ActionResult RemoveFromCart(int productId,string returnUrl)
    {

    }
  }
}
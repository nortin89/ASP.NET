using SportsStore.Abstract;
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

    private IOrderProcessor orderProcessor;

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

    [HttpPost]
    public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
    {
      if (cart.Lines.Count() == 0)
      {
        ModelState.AddModelError("", "Sorry, your cart is empty!");
      }
      if (ModelState.IsValid)
      {
        orderProcessor.ProcessOrder(cart, shippingDetails);
        cart.Clear();
        return View("Completed");
      }
      else
      {
        return View(shippingDetails);

      }
    }

    // GET: Cart
    public ViewResult Index(Cart cart, string returnUrl)
    {
      ViewBag.returnUrl = returnUrl;

      return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl});

    }

    //public ViewResult Index(string returnUrl)
    //{
    //  return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
    //}

    [HttpPost]
    public RedirectToRouteResult AddToCart(Cart cart, int productId,string returnUrl)
    {
      //Find, Single, First, Last
      //FirstOrDefault, SingleOrDefault, LastOrDefault

      Product product = _db.Products.SingleOrDefault(x => x.ProductID == productId);
      if(product != null)
      {
        cart.Add(product, 1);
      }
      return RedirectToAction("Index", routeValues: new { returnUrl });

    }

    [HttpPost]
    public ActionResult RemoveFromCart(Cart cart, int productId, string returnUrl)
    {
      Product product = _db.Products.FirstOrDefault(x => x.ProductID == productId);

      if(product != null)
      {
        cart.Remove(product);
      }
      return RedirectToAction("Index", new { returnUrl });
    }

    public PartialViewResult Summary(Cart cart)
    {
      return PartialView(cart);
    }
    //private Cart GetCart()
    //{
    //  Cart cart = (Cart)Session["Cart"];
    //  if(cart == null)
    //  {
    //    cart = new Cart();
    //    Session["Cart"] = cart;
    //  }
    //  return cart;
    //}
  }
}
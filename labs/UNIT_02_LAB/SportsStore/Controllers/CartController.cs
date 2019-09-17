
using SportsStore.Infrastructure.Binders;

using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
  public class CartController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    [HttpGet]
    public ActionResult CheckOut(Cart cart)
    {
      if (cart.IsEmpty)
      {
        ModelState.AddModelError("", "Sorry, your cart is empty!");
      }
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Checkout(Cart cart, ShippingDetails shippingInfo)
    {
      if (cart.IsEmpty)
      {
        ModelState.AddModelError("", "Sorry, your cart is empty!");
      }
      ////Check if ModelState is valid
      if (!ModelState.IsValid)
      {
        return View(shippingInfo);
      }
      try
      {
        await SaveOrderToDatabase(cart, shippingInfo);
        await SendOrderEmail(cart, shippingInfo);
        cart.Clear();
        return RedirectToAction("Completed");
        //throw new NullReferenceException("something went wrong");
      }
      catch (Exception ex)
      {
        return View("Error", ex);
      }

    }

    public ActionResult Completed()
    {
      return View();
    }

    public ViewResult Index(Cart cart, string returnUrl)
    {
      ViewBag.returnUrl = returnUrl;

      return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });

    }

    [HttpPost]
    public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
    {
      //Find, Single, First, Last
      //FirstOrDefault, SingleOrDefault, LastOrDefault

      Product product = _db.Products.SingleOrDefault(x => x.ProductID == productId);
      if (product != null)
      {
        cart.Add(product, 1);
      }
      return RedirectToAction("Index", routeValues: new { returnUrl });

    }

    [HttpPost]
    public ActionResult RemoveFromCart(Cart cart, int productId, string returnUrl)
    {
      Product product = _db.Products.FirstOrDefault(x => x.ProductID == productId);

      if (product != null)
      {
        cart.Remove(product);
      }
      return RedirectToAction("Index", new { returnUrl });
    }

    public PartialViewResult Summary(Cart cart)
    {
      return PartialView(cart);
    }

    private async Task SendOrderEmail(Cart cart, ShippingDetails shippingInfo)
    {
      StringBuilder body = new StringBuilder()
        .AppendLine("<h1>A new order has been submitted</h1>")
        .AppendLine("---")
        .AppendLine("<h2>Items:</h2>");
      foreach (var line in cart.Lines)
      {
        body.AppendLine($"{line.Quantity} x {line.Product.Name} @ {line.Product.Price:c} each <br/>");
      }

      body.AppendLine($"<br/>Subtotal: {cart.ComputeTotalValue():c}");
      body.AppendLine("<h2>Ship To</h2>");
      body.Append(shippingInfo.Name).Append("<br/>");
      body.AppendLine(shippingInfo.Line1).Append("<br/>");
      if (shippingInfo.Line2 != null) { body.Append(shippingInfo.Line2).Append("<br/>"); }
      if (shippingInfo.Line3 != null) { body.Append(shippingInfo.Line3).Append("<br/>"); }
      if (shippingInfo.City != null) { body.Append(shippingInfo.City).Append("<br/>"); }
      if (shippingInfo.State != null) { body.Append(shippingInfo.State).Append("<br/>"); }
      if (shippingInfo.Country != null) { body.Append(shippingInfo.Country).Append("<br/>"); }
      if (shippingInfo.Zip != null) { body.Append(shippingInfo.Zip).Append("<br/>"); }
      body.AppendFormat("<h2>Gift wrap: {0}</h2>", shippingInfo.GiftWrap ? "Yes" : "No");

      using (SmtpClient smtp = new SmtpClient())
      {
        string host = Environment.GetEnvironmentVariable("SMTP_HOST");
        string port = Environment.GetEnvironmentVariable("SMTP_PORT");
        string user = Environment.GetEnvironmentVariable("SMTP_USER");
        string pass = Environment.GetEnvironmentVariable("SMTP_PASSWORD");

        smtp.Host = host;
        smtp.Port = int.Parse(port);
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(user, pass);

        using (MailMessage message = new MailMessage())
        {
          message.From = new MailAddress(user);
          message.To.Add(new MailAddress(user));
          message.Subject = "New Order Submitted!";
          message.Body = body.ToString();
          message.IsBodyHtml = true;

          smtp.Send(message);
        }
      }
    }
    private async Task SaveOrderToDatabase(Cart cart, ShippingDetails shippingInfo)
    {
      var order = new Order
      {
        OrderDate = DateTime.Now
      };
      _db.Orders.Add(order);
      await _db.SaveChangesAsync();

      //foreach (CartLine line in cart.Lines)
      //{
      //  _db.OrderLines.Add(new OrderLine
      //  {
      //    OrderID = order.OrderID,
      //    ProductID = line.Product.ProductID,
      //    Quantity = line.Quantity,
      //    PricePerUnit = line.Product.Price
      //  });
      //}
      var lines = cart.Lines.Select(x => new OrderLine
      {
        OrderID = order.OrderID,
        ProductID = x.Product.ProductID,
        Quantity = x.Quantity,
        PricePerUnit = x.Product.Price
      });
      _db.OrderLines.AddRange(lines);
      await _db.SaveChangesAsync();
    }
  }
}
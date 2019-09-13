using HOT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOT1.Controllers
{
    public class OrderFormController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public ActionResult Index(OrderForm order)
    {

      if(order.DiscountCode == null)
      {
        ViewBag.Quantity = order.Quantity;
        ViewBag.PricePerShirt = 15;
        ViewBag.Subtotal = (order.Quantity) * ViewBag.PricePerShirt;
        ViewBag.Tax = ViewBag.Subtotal * .08;
        ViewBag.Total = (ViewBag.Tax + ViewBag.Subtotal);
      }
      else if (order.DiscountCode.ToLower() == "BB88")
      {
        order.Total = order.Total - Convert.ToSingle(order.Total * .20);
      }
      else if (order.DiscountCode.ToLower() == "CC99")
      {
        order.Total = order.Total - Convert.ToSingle(order.Total * .10);
      }
            return View("Index");
    }
    }
}
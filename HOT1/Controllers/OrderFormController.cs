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
      order.PricePerShirt = 15;

      if(order.DiscountCode == "" || order.DiscountCode == null)
      {

      }
      else if(order.DiscountCode == "6175")
      {
        order.PricePerShirt *= 0.7f;
        order.DiscountMessage = "30% Discount Applied";

      }
      else if(order.DiscountCode == "1390")
      {
        order.PricePerShirt *= 0.8f;
        order.DiscountMessage = "20% Discount Applied";

      }
      else if(order.DiscountCode == "BB88")
      {
        order.PricePerShirt *= 0.9f;
        order.DiscountMessage = "10% Discount Applied";

      }
      else
      {
        order.DiscountMessage = "Invalid Discount Code";
      }


      order.Subtotal = (order.Quantity ?? 0) * order.PricePerShirt;
      order.Tax = order.Subtotal * .08f;
      order.Total = order.Tax + order.Subtotal;
      return View("Index",order);

    }
  }
}
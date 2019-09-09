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
      ViewBag.Quantity = order.Quantity;
      ViewBag.PricePerShirt = 15;
      ViewBag.Subtotal = (order.Quantity)*15;
      ViewBag.Tax = ViewBag.Subtotal * .08;
      ViewBag.Total = (ViewBag.Tax + ViewBag.Subtotal);
      return View("Index");
    }
    }
}
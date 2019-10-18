using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
  public class ContactController : Controller
  {
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(ContactViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return Json(new { Success = false, Message = "Inavalid Data" });
      }

      //FIX ME: SEND EMAIL
      return Json(new { Success = true,Message = "Message Sent"});
    }
  }
}
using Porfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Porfolio.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      else
      {
        return RedirectToAction("Index", "Chat", new { user = model.UserName });
      }
    }
  }
}
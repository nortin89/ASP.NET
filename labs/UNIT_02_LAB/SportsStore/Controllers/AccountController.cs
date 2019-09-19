using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SportsStore.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    [Obsolete]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      else if (FormsAuthentication.Authenticate(model.UserName, model.Password))
      {
        FormsAuthentication.SetAuthCookie(model.UserName, false);
        return Redirect(returnUrl ?? Url.Action("Index","Admin"));
      }
      else
      {
        ModelState.AddModelError("", "Incorrect username or password");
        return View();
      }
    }
  }
}
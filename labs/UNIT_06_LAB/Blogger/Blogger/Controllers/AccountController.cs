using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blogger.Controllers
{
  public class AccountController : Controller
  {
    // GET: Account
    public ActionResult Login()
    {
      return View();
    }



    [HttpPost]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      else if (FormsAuthentication.Authenticate(model.UserName, model.Password))
      {
        FormsAuthentication.SetAuthCookie(model.UserName, false);
        return Redirect(returnUrl ?? Url.Action("EditPost", "Blog"));
      }
      else
      {
        ModelState.AddModelError("", "Incorrect username or password");
        return View();
      }
    }
  }
}
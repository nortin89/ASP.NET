using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogger.Controllers
{
  public class PhotosController : Controller
  {
    private BloggerDatabase _db = new BloggerDatabase();
    // GET: Photos
    public ActionResult Index()
    {
      return View();
    }
  }
}
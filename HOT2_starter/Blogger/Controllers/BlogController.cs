using Blogger.Models;
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

namespace Blogger.Controllers
{
  public class BlogController : Controller
  {
    private BloggerDatabase _db = new BloggerDatabase();

    public ActionResult Index()
    {
      // FIXME: implement this action method
      return View();
    }

    [HttpGet]
    public ActionResult CreatePost()
    {
      // FIXME: implement this action method
      return View("EditPost");
    }

    [HttpGet]
    public ActionResult EditPost(int postId)
    {
      // FIXME: implement this action method
      return View("EditPost");
    }

    [HttpPost]
    public ActionResult SubmitPost(BlogPost post)
    {
      // FIXME: implement this action method
      return View("EditPost");
    }

    [HttpPost]
    public ActionResult SubmitComment(BlogComment comment)
    {
      // FIXME: implement this action method
      return View("Index");
    }
  }
}
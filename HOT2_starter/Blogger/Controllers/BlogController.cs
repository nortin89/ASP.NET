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
      return View(_db.BlogPosts);
    }

    [HttpGet]
    public ActionResult CreatePost()
    {
      // FIXME: implement this action method
      return View("EditPost",new BlogPost());
    }

    [HttpGet]
    public ActionResult EditPost(int postId)
    {
      BlogPost post = _db.BlogPosts.SingleOrDefault(x => x.BlogPostId == postId);
      // FIXME: implement this action method
      return View("EditPost",post);
    }

    [HttpPost]
    public async Task<ActionResult> SubmitPost(BlogPost post)
    {
      if (!ModelState.IsValid)
      {
        return View("EditPost",post);
      }
      else if(post.BlogPostId == 0)
      {
        _db.BlogPosts.Add(post);
        await _db.SaveChangesAsync();
        TempData["message"] = $"{post.Title} has been submited";
        return RedirectToAction("Index");
      }
      else
      {
        BlogPost dbEntry = _db.BlogPosts.SingleOrDefault(x => x.BlogPostId == post.BlogPostId);
        dbEntry.Title = post.Title;
        dbEntry.Posted = post.Posted;
        dbEntry.Text = post.Text;
        await _db.SaveChangesAsync();
        TempData["message"] = $"{post.Title} has been changed";
        return RedirectToAction("Index");
      }
      // FIXME: implement this action method
    }

    [HttpPost]
    public async Task<ActionResult> SubmitComment(BlogComment comment)
    {
      if (!ModelState.IsValid)
      {
        return View("EditPost", comment);
      }
      else if (comment.BlogCommentId == 0)
      {
        _db.BlogComments.Add(comment);
        await _db.SaveChangesAsync();
        TempData["message"] = $"{comment.AuthorName} left a comment";
        return RedirectToAction("Index");
      }
      else
      {
        BlogComment dbEntry = _db.BlogComments.SingleOrDefault(x => x.BlogCommentId == comment.BlogCommentId);
        dbEntry.AuthorName = comment.AuthorName;
        dbEntry.BlogPost = comment.BlogPost;
        dbEntry.Text = comment.Text;
        await _db.SaveChangesAsync();
        TempData["message"] = $"{comment.AuthorName} left a comment";
        return RedirectToAction("Index");
      }
      // FIXME: implement this action method
      //return View("Index");
    }
  }
}
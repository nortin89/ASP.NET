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

    public ActionResult PostsAndComments()
    {
      var postsAndComments = from p in _db.BlogPosts
                             join c in _db.BlogComments
                             on p.BlogPostId equals c.BlogPostId
                             orderby
                             p.Posted descending, p.BlogPostId descending,
                             c.Posted descending, c.BlogCommentId descending
                             select new BlogCommentViewModel
                             {
                               PostTitle = p.Title,
                               PostPosted = p.Posted,
                               PostText = p.Text,
                               CommentAuthor = c.AuthorName,
                               CommentPosted = c.Posted,
                               CommentText = c.Text
                             };

      ViewBag.Comments = postsAndComments;
      return View("PostsAndComments");
    }

    public async Task<ActionResult> Index(int page = 1, int pageSize = 3,string q = null)
    {
      var posts = await _db.BlogPosts.
        //Include("BlogPhotos").
        Include("BlogComments").
        Where(x => q == null || x.Tags.Contains(q) || x.Text.Contains(q) || x.Title.Contains(q)).
        OrderByDescending(x => x.Posted).
        ThenByDescending(x => x.BlogPostId).
        Skip((page - 1) * pageSize).
        Take(pageSize).
        ToListAsync();

      var count =
        await _db.BlogPosts.Where(x => q == null || 
        x.Tags.Contains(q) || 
        x.Text.Contains(q) || 
        x.Title.Contains(q))
                .CountAsync();

      ViewBag.PagingInfo = new PagingInfo
      {
        CurrentPage = page,
        ItemsPerPage = pageSize,
        TotalItems = count,
        Query = q,
        
      };
      return View(posts);
    }

    [HttpGet]
    [Authorize]
    public ActionResult CreatePost()
    {
      var post = new BlogPost();
      post.Posted = DateTime.Now;
      return View("EditPost",post);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> EditPost(int postId)
    {
      var post = await _db.BlogPosts.SingleOrDefaultAsync(x => x.BlogPostId == postId);
      return View("EditPost",post);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> SubmitPost(BlogPost post)
    {
      if (!ModelState.IsValid)
      {
        return View("EditPost",post);
      }
      else if(post.BlogPostId == 0)
      {
        post.Posted = DateTime.Now;
        _db.BlogPosts.Add(post);
        await _db.SaveChangesAsync();


        TempData["message"] = "Blog posted created";
        return RedirectToAction("Index");
      }
      else
      {
        var dbEntry = _db.BlogPosts.SingleOrDefault(x => x.BlogPostId == post.BlogPostId);
        dbEntry.Title = post.Title;
        dbEntry.Text = post.Text;
        dbEntry.Tags = post.Tags;
        await _db.SaveChangesAsync();

        TempData["message"] = "Blog posted updated";
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<ActionResult> SubmitComment(BlogComment comment)
    {
      if (!ModelState.IsValid)
      {
        var message = new StringBuilder();
        message.AppendLine("Failed to save comment<ul>");
        foreach (var error in ModelState)
        {
          message.AppendLine($"<li>{error.Value}</li>");
        }
        message.AppendLine("</ul>");
        TempData["message"] = message;
        return RedirectToAction("Index");
      }
      else
      {
        var post = await _db.BlogPosts.SingleOrDefaultAsync(x => x.BlogPostId == comment.BlogCommentId);

        comment.Posted = DateTime.Now;
        _db.BlogComments.Add(comment);
        await _db.SaveChangesAsync();

        TempData["message"] = "Comment posted";
        return RedirectToAction("Index");

      }

    }
  }
}
using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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

    public async Task<ActionResult> Index(
      int page = 1,
      int pageSize = 3,
      string text = null,
      string q = null)
    {
      IQueryable<BlogPost> query = _db.BlogPosts;

      if (!string.IsNullOrWhiteSpace(text))
      {
        query = query.Where(x => x.Text == text);
      }
      if (!string.IsNullOrWhiteSpace(q))
      {
        string[] keywords = Regex.Split(q, @"\s+");
        foreach(string word in keywords)
        {
          query = query.Where(x => x.Title.Contains(word) ||
                                   x.Tags.Contains(word) ||
                                   x.Text.Contains(word));
        }
      }

      int totalCount = await query.CountAsync();

      List<BlogPost> posts =
        await query.OrderBy(x => x.Title)
                   .ThenBy(x => x.BlogPostId)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize).ToListAsync();

      var model = new BlogListViewModel
      {
        BlogPosts = posts,
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = totalCount,
        },
        Text = text,
        Query = q
      };

      return View(model);
    }

    public async Task<ActionResult> Keywords(string term)
    {
      term = term.ToLower();

      var title =
        await _db.BlogPosts
                 .Where(x => x.Title.Contains(term))
                 .Select(x => x.Title.ToLower())
                 .Distinct()
                 .ToListAsync();

      var tags = await _db.BlogPosts
                          .Where(x => x.Tags.Contains(term))
                          .Select(x => x.Tags.ToLower())
                          .Distinct()
                          .ToListAsync();

      var splitTags =
                tags.SelectMany(x => Regex.Split(x, @"\s*,\s*"))
                    .Where(x => x.Contains(term));

      var serverDir = Server.MapPath("~/");

      var spelling = new NHunspell.Hunspell(
        serverDir + "en_US.aff",
        serverDir + "sportsstore.dic");

      var suggestions =
        spelling.Spell(term) ?
        new List<string>() { term } :
        spelling.Suggest(term).Take(5);

      var results =
        title.Union(splitTags)
                  .OrderBy(x => x)
                  .Distinct();

      results = suggestions.Union(results);

      return Json(results, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> CreatePost()
    {
      await PopulatePhotoDropdown();

      var post = new BlogPost();
      post.Posted = DateTime.Now;
      post.Photos = new List<BlogPostPhoto>();

      while (post.Photos.Count < 3)
      {
        post.Photos.Add(new BlogPostPhoto());
      }

      return View("EditPost", post);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> EditPost(int postId)
    {
      var post =
        await _db.BlogPosts.SingleOrDefaultAsync(x => x.BlogPostId == postId);
      if (post.Photos == null)
      {
        post.Photos = new List<BlogPostPhoto>();
      }
      while (post.Photos.Count < 3)
      {
        post.Photos.Add(new BlogPostPhoto() { BlogPostId = post.BlogPostId});
      }

      await PopulatePhotoDropdown();
      return View("EditPost", post);
    }

    private async Task PopulatePhotoDropdown()
    {
      List<Photo> photos =
        await _db.Photos.OrderBy(x => x.ImageName).ToListAsync();

      ViewBag.Photos = photos;
      //_db.Photos.Add(photos);
      //return RedirectToAction("Index");
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> SubmitPost(BlogPost post)
    {
      if (!ModelState.IsValid)
      {
        await PopulatePhotoDropdown();
        return View("EditPost", post);
      }
      else if (post.BlogPostId == 0)
      {
        //Create new Post
        post.Posted = DateTime.Now;
        _db.BlogPosts.Add(post);

        for (int i = post.Photos.Count - 1; i >= 0; --i)
        {
          if (post.Photos[i].PhotoId != null)
          {
            post.Photos[i].BlogPost = post;
            _db.BlogPostPhotos.Add(post.Photos[i]);

          }
          else
          {
            post.Photos.RemoveAt(i);
          }
        }
        await _db.SaveChangesAsync();
        TempData["message"] = $"{post.Title} has been inserted";
        return RedirectToAction("Index");
      }
      else
      {
        //Edit existing Post
        var dbEntry = _db.BlogPosts.SingleOrDefault(x => x.BlogPostId == post.BlogPostId);
        dbEntry.Title = post.Title;
        dbEntry.Text = post.Text;
        dbEntry.Tags = post.Tags;

        //Remove items from the model that do not have a photo selected
        for (int i = post.Photos.Count - 1; i >= 0; --i)
        {
          if (post.Photos[i].PhotoId == null)
          {
            post.Photos.RemoveAt(i);
          }
        }

        // Add new photos
        var photosToAdd = new List<BlogPostPhoto>();
        foreach (var photo in post.Photos)
        {
          if (!dbEntry.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToAdd.Add(photo);
          }
        }
        _db.BlogPostPhotos.AddRange(photosToAdd);

        //Remove existing photos
        var photosToRemove = new List<BlogPostPhoto>();
        foreach (var photo in dbEntry.Photos)
        {
          if (!post.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToRemove.Add(photo);
          }
        }
        _db.BlogPostPhotos.RemoveRange(photosToRemove);

        await _db.SaveChangesAsync();
        TempData["message"] = $"{post.Title} has been updated";
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<ActionResult> LikePost(int? blogPostId)
    {
      BlogPost post = await _db.BlogPosts.SingleOrDefaultAsync(x => x.BlogPostId == blogPostId);
      post.Likes++;

      await _db.SaveChangesAsync();

      return Json(new { Success = true, Message = "You Liked Post" ,LikeCount = post.Likes});
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
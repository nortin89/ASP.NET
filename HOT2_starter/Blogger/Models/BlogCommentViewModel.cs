using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  public class BlogCommentViewModel
  {
    public string PostTitle { get; set; }
    public DateTime? PostPosted { get; set; }
    public string PostText { get; set; }
    public string CommentAuthor { get; set; }
    public DateTime? CommentPosted { get; set; }
    public string CommentText { get; set; }

  }
}
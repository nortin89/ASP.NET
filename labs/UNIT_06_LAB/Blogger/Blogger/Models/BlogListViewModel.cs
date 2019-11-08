using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  public class BlogListViewModel
  {
    public List<BlogPost> BlogPosts { get; set; }
    public PagingInfo PagingInfo { get; set; }
    public string Text { get; set; }
    public string Query { get; set; }
  }
}
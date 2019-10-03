using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Blogger.Models
{
  public partial class BloggerDatabase : DbContext
  {
    public BloggerDatabase()
        : base("name=BloggerDatabase")
    {
    }

    public virtual DbSet<BlogComment> BlogComments { get; set; }
    public virtual DbSet<BlogPost> BlogPosts { get; set; }
    public virtual DbSet<BlogPostPhoto> BlogPostPhotos { get; set; }
    public virtual DbSet<Photo>Photos { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}

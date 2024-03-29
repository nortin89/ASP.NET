using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Blogger.Models
{
  [Table("BlogPosts")]
  public partial class BlogPost
  {
    [Display(Name = "Post ID")]
    [Key]
    [HiddenInput(DisplayValue = false)]
    public int BlogPostId { get; set; }

    [Display(Name = "Post Title")]
    [Required(ErrorMessage = "Please enter the title of your post")]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
    public string Title { get; set; }

    [Display(Name = "Posted Posted On")]
    [Required(ErrorMessage = "Please enter the current date and time")]
    [HiddenInput(DisplayValue = false)]
    public DateTime? Posted { get; set; }

    [Display(Name = "Post Text")]
    [Required(ErrorMessage = "Please enter your post")]
    [StringLength(4000, ErrorMessage = "Comment must be 4000 characters or less")]
    public string Text { get; set; }

    [ForeignKey("BlogPostId")]
    public virtual IList<BlogComment> BlogComments { get; set; }

    //public string Query { get; set; }

    [StringLength(100)]
    public string Tags { get; set; }

    public virtual IList<BlogPostPhoto> Photos { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Blogger.Models
{
  [Table("BlogComments")]
  public partial class BlogComment
  {
    [Display(Name = "Comment ID")]
    [Key]
    [HiddenInput(DisplayValue = false)]
    public int BlogCommentId { get; set; }

    [Display(Name = "Post ID")]
    [Required(ErrorMessage = "Please select a blog post")]
    [HiddenInput(DisplayValue = false)]
    public int? BlogPostId { get; set; }

    [Display(Name = "Your Name")]
    [Required(ErrorMessage = "Please enter your name")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string AuthorName { get; set; }

    [Display(Name = "Comment Posted On")]
    [Required(ErrorMessage = "Please enter the current date and time")]
    [HiddenInput(DisplayValue = false)]
    public DateTime? Posted { get; set; }

    [Display(Name = "Comment Text")]
    [Required(ErrorMessage = "Please enter your comment")]
    [StringLength(1000, ErrorMessage = "Comment must be 1000 characters or less")]
    public string Text { get; set; }

    [ForeignKey("BlogPostId")]
    public virtual BlogPost BlogPost { get; set; }
  }
}

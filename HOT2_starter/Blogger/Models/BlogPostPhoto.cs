using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  [Table("BlogPostPhotos")]
  public class BlogPostPhoto
  {
    [Key]
    [Column(Order = 0)]
    public int? BlogPostId { get; set; }

    [Key]
    [Display(Name ="Photo")]
    [Column(Order = 1)]
    public int? PhotoId { get; set; }


    public virtual BlogPost BlogPost { get; set; }

    public virtual Photo Photo { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  public class BlogPostPhoto
  {
    [Key]
    public int? BlogPostId { get; set; }

    [Required]
    [StringLength(100)]
    public string ImageName { get; set; }

    //[Required]
    public byte[] ImageData { get; set; }

    //[Required]
    [StringLength(100)]
    public string ImageMimeType { get; set; }
  }
}
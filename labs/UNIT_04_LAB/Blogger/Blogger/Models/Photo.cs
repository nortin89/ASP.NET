using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  [Table("Photos")]
  public class Photo
  {
    [Key]
    public int? PhotoId { get; set; }

    [Required]
    [StringLength(100)]
    public string ImageName { get; set; }

    //[Required]
    public byte[] ImageData { get; set; }

    //[Required]
    [StringLength(100)]
    public string ImageMimeType { get; set; }

    public virtual IList<BlogPostPhoto> Posts { get; set; }

  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HOT4.Models
{
  [Table("Photos")]
  public class Photo
  {
    [Key]
    public int? PhotoId { get; set; }

    [Display(Name = "Resume ID")]
    public int? ResumeId { get; set; }

    [Required]
    [StringLength(100)]
    public string ImageName { get; set; }

    public byte[] ImageData { get; set; }

    [StringLength(100)]
    public string ImageMimeType { get; set; }

    public virtual IList<ResumePhoto> Photos { get; set; }
  }
}
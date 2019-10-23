using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HOT4.Models
{
  [Table("ResumePhotos")]
  public class ResumePhoto
  {
    [Key]
    [Column(Order = 0)]
    public int? ResumeId { get; set; }

    [Key]
    [Display(Name = "Photo")]
    [Column(Order = 1)]
    public int? PhotoId { get; set; }

    public virtual Resume Resume { get; set; }

    public virtual Photo Photo { get; set; }


  }
}
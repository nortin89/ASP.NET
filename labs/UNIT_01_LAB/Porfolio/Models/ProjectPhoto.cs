using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Porfolio.Models
{
  public class ProjectPhoto
  {
    [Key]
    public int ProjectPhotoId { get; set; }
    public int ProjectId { get; set; }
    public int Order { get; set; }
    public string FileName { get; set; }


  }
}
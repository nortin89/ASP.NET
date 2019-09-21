using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Porfolio.Models
{
  public class ProjectTag
  {
    [Key]
    public int? ProjectTagId { get; set; }

    public int? ProjectId { get; set; }

    public string Name { get; set; }

  }
}
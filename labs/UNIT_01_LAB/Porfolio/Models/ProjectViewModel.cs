using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Porfolio.Models
{
  public class ProjectViewModel
  {
    public int ProjectID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Photos { get; set; }
    public string[] Tags { get; set; }
  }
}
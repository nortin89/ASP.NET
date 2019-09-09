using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Experiment.Models
{
  public class TempInput
  {

    [Required(ErrorMessage = "Please enter a Fahrenheit temp")]
    public double? Fahrenheit { get; set; }

    public double? Celsius { get; set; }

    public double? Kelvin { get; set; }
  }
}
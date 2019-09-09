using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HOT1.Models
{
  public class DistanceConverter
  {
    [Required(ErrorMessage = "Please enter in a Distance in Inches")]
    public float DistanceInInches { get; set; }
    public float DistanceInCentimeters { get; set; }

  }
}
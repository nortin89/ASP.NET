using System.ComponentModel.DataAnnotations;

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
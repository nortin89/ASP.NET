using System.ComponentModel.DataAnnotations;

namespace MpgCalc.Models
{
  public class MpgCalcModel
  {
    //Inputs

    [Required(ErrorMessage = "Please enter how miles you drive")]
    public decimal? MilesDriven { get; set; }

    [Required(ErrorMessage = "Please enter the number of gallons that you used")]
    public decimal? GallonsUsed { get; set; }

    [Required(ErrorMessage = "Please enter price per gallon")]
    public decimal? PricePerGallon { get; set; }

    //Outputs
    public decimal? Mpg { get; set; }
    public decimal? TripCost { get; set; }
    public decimal? CostPerMile { get; set; }
  }
}
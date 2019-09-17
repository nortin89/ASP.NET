using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HOT1.Models
{
  public class OrderForm
  {
    [Required(ErrorMessage = "Please enter valid Quantity")]
    public int? Quantity { get; set; }
    public string DiscountCode { get; set; }
    public string DiscountMessage { get; set; }
    public float PricePerShirt { get; set; }
    public float Subtotal { get; set; }
    public float Tax { get; set; }
    public float Total { get; set; }
  }
}
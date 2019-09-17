using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
  public class Order
  {
    [Key]
    public int OrderID { get; set; }

    [Display(Name="Order Date")]
    [Required(ErrorMessage = "Order date is required")]
    public DateTime? OrderDate { get; set; }

    [Display(Name = "Ship Date")]
    public DateTime? ShipDate { get; set; }
  }
}
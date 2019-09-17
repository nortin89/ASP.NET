using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
  public class OrderLine
  {
    [Column(Order = 0)]
    [Key]
    [Required]
    public int? OrderID { get; set; }

    [Column(Order = 1)]
    [Key]
    [Required]
    public int? ProductID { get; set; }

    [Column(Order = 2)]
    [Required]
    public int? Quantity { get; set; }

    [Column(Order = 3)]
    [Required]
    public decimal? PricePerUnit { get; set; }
  }
}
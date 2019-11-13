namespace WorkOrders.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Part
  {
    [Key]
    public int? PartId { get; set; }

    [Required]
    public int? CustomerId { get; set; }

    [Required]
    public int? OrderId { get; set; }

    [StringLength(50)]
    [Required]
    public string PartName { get; set; }

    [Required]
    public int? Quantity { get; set; }

    [Required]
    public int? PartNumber { get; set; }

    [Required]
    public decimal? PartCost { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Order Order { get; set; }
  }
}

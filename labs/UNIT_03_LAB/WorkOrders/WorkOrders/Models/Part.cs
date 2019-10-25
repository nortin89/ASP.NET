namespace WorkOrders.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Part
  {
    public int? PartId { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderId { get; set; }

    [StringLength(50)]
    public string PartName { get; set; }

    public int? Quantity { get; set; }

    public int? PartNumber { get; set; }

    public decimal? PartCost { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Order Order { get; set; }
  }
}

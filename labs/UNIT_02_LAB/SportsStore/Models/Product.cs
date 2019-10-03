namespace SportsStore.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;
  using System.Web.Mvc;

  public partial class Product
  {
    [Key]
    [HiddenInput(DisplayValue = false)]
    public int ProductID { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter a description")]
    [StringLength(500)]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Please specify a category")]
    [StringLength(50)]
    public string Category { get; set; }

    [Required(ErrorMessage = "Please enter a positive price")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
    public decimal? Price { get; set; }

    [StringLength(100)]
    public string Tags { get; set; }

    public int? PhotoId { get; set; }

  }
}

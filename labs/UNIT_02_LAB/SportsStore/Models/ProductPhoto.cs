﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
  [Table("ProductPhotos")]
  public class ProductPhoto
  {
    [Key]
    [Column(Order = 0)]
    public int? ProductID { get; set; }

    [Key]
    [Display(Name = "Photo")]
    [Column(Order = 1)]
    public int? PhotoId { get; set; }


    public virtual Product Product { get; set; }

    public virtual Photo Photos { get; set; }
  }
}
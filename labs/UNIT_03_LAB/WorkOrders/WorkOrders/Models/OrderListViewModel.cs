using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WorkOrders.HtmlHelpers;

namespace WorkOrders.Models
{
  public class OrderListViewModel
  {
    public List<Order> Orders { get; set; }
    
    public PagingInfo PagingInfo { get; set; }

    public string ClientName { get; set; }

    public int? OrderNumber { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? EndDate { get; set; }

  }
}
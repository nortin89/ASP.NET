using System;
using System.Collections.Generic;
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
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    //public string Query { get; set; }
  }
}
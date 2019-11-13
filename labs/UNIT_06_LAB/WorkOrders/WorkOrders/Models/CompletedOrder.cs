using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WorkOrders.Models
{
  [Table("Completed Orders")]
  public class CompletedOrder
  {
    [Key]
    [Display(Name = "Order ID")]
    public int Id { get; set; }

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Please enter your email address.")]
    [StringLength(200, ErrorMessage = "Email is too long.")]
    [MinLength(3, ErrorMessage = "Email is too short.")]
    [RegularExpression(@"^(.+)@(.+\.\w+)$", ErrorMessage = "Email address is invalid. Please check that you have entered it correctly.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Email Confirmed")]
    public bool IsConfirmed { get; set; }

    [Display(Name = "Subscribed to Blogger")]
    public bool IsSubscribed { get; set; }

    [Display(Name = "URL to Unsubscribe")]
    public string UnsubscribeUrl { get; set; }
  }
}
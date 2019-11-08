using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
  [Table("Subscribers")]
  public class Subscribers
  {
    [Key]
    [Required(ErrorMessage = "Please enter your email address")]
    [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }

    //[Required(ErrorMessage = "Please enter your phone number")]
    //public string Phone { get; set; }

    [Required(ErrorMessage = "Please specify whether you'll attend")]
    public bool? IsSubscribed { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
  public class ContactViewModel
  {
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Porfolio.Models
{
  public class LoginViewModel
  {
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "Please Enter A User Name")]
    [StringLength(20)]
    [MinLength(3)]

    public string UserName { get; set; }
  }
}
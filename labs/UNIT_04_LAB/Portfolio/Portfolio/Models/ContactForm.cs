﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
  public class ContactForm
  {
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }


    [Required(ErrorMessage = "Please enter valid Email")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Please enter a Message")]
    public string Message { get; set; }
  }
}
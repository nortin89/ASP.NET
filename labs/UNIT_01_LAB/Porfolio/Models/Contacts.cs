using System.ComponentModel.DataAnnotations;

namespace Porfolio.Models
{
  public class Contacts
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
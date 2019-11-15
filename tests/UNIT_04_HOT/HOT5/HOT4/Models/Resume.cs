
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;
using System.Text.RegularExpressions;

namespace HOT4.Models
{
  [Table("Resumes")]
  public partial class Resume
  {
    [Key]
    [Display(Name = "Resume ID")]
    public int ResumeId { get; set; }

    public int? PhotoId { get; set; }

    [Required(ErrorMessage ="Full Name is required")]
    [StringLength(100)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    [StringLength(200, ErrorMessage ="Name is too long. ")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [StringLength(200,ErrorMessage ="Email is too long. ")]
    [Display(Name = "Email Address")]
    [EmailAddress(ErrorMessage ="Must be a valid email address. ")]
    public string EmailAddress { get; set; }

    [StringLength(100)]
    [Display(Name = "LinkedIn Profile")]
    public string LinkedIn { get; set; }

    [Display(Name = "Formal Education")]
    public virtual IList<Education> Educations { get; set; }

    [Display(Name = "Past Jobs")]
    public virtual IList<Job> Jobs { get; set; }

    [Display(Name = "Relevant Projects")]
    public virtual IList<Project>Projects { get; set; }

    [Display(Name = "Top Skill")]
    public virtual IList<Skill> Skills { get; set; }

    [Display(Name = "Last Update")]
    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime? LastUpdate { get; set; }

    //public virtual IList<Photo>Photos { get; set; }

    public virtual IList<ResumePhoto> Photos { get; set; }


  }
}


  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

namespace HOT4.Models
{
  [Table("Resumes")]
  public partial class Resume
  {
    [Key]
    [Display(Name = "Resume ID")]
    public int ResumeId { get; set; }

    [Required(ErrorMessage ="Full Name is required")]
    [StringLength(100)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    [StringLength(100)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [StringLength(100)]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [StringLength(100)]
    [Display(Name = "LinkedIn Profile")]
    public string LinkedIn { get; set; }

    [Display(Name = "Formal Education")]
    public virtual IList<Education> FormalEducation { get; set; }

    [Display(Name = "Past Jobs")]
    public virtual IList<Job> PastJob { get; set; }

    [Display(Name = "Relevant Projects")]
    public virtual IList<Project>ReleventProject { get; set; }

    [Display(Name = "Top Skill")]
    public virtual IList<Skill> TopSkill { get; set; }

    [Display(Name = "Last Update")]
    public DateTime? LastUpdate { get; set; }


    public virtual IList<ResumePhoto> Photos { get; set; }


  }
}

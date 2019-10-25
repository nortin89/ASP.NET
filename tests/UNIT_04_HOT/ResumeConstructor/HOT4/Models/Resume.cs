namespace HOT4.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  public partial class Resume
  {
    [Key]
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

    [Display(Name = "Formal Education")]
    public virtual IList<FormalEducation> FormalEducation { get; set; }

    [Display(Name = "Past Jobs")]
    public virtual IList<PastJob> PastJob { get; set; }

    [Display(Name = "Relevant Projects")]
    public virtual IList<ReleventProject>ReleventProject { get; set; }

    [Display(Name = "Top Skill")]
    public virtual IList<TopSkill> TopSkill { get; set; }

    [Display(Name = "Last Update")]
    public DateTime? LastUpdate { get; set; }


    public virtual IList<ResumePhoto> Photos { get; set; }


  }
}

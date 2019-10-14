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
    public int ApplicantId { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [Required]
    [StringLength(100)]
    public string PhoneNumber { get; set; }

    [Required]
    [StringLength(100)]
    public string EmailAddress { get; set; }

    public virtual FormalEducation FormalEducation { get; set; }

    public virtual PastJob PastJob { get; set; }

    public virtual ReleventProject ReleventProject { get; set; }

    public virtual TopSkill TopSkill { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual IList<ResumePhoto> Photos { get; set; }


  }
}

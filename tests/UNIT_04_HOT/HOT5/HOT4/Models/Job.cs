namespace HOT4.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Jobs")]
  public partial class Job
  {
    [Key]
    [Display(Name = "Job ID")]
    public int JobId { get; set; }

    
    [Display(Name = "Resume ID")]
    public int ResumeId { get; set; }

    [Required]
    [StringLength(100)]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(500)]
    public string CompanyAddress { get; set; }

    [Required]
    [StringLength(100)]
    public string ManagerName { get; set; }

    [StringLength(100)]
    public string ManagerPhone { get; set; }

    [Required]
    [StringLength(100)]
    public string Position { get; set; }

    public virtual Resume Resume { get; set; }
  }
}

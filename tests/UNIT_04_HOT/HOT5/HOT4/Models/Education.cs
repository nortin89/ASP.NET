namespace HOT4.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Education")]
  public partial class Education
  {
    [Key]
    public int EducationId { get; set; }


    public int ResumeId { get; set; }

    [Required]
    [StringLength(100)]
    public string SchoolName { get; set; }

    [Required]
    [StringLength(100)]
    public string Degree { get; set; }

    [Required]
    [StringLength(100)]
    public string Subject { get; set; }

    [Column(TypeName = "date")]
    [Display(Name = "Start Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    [Display(Name = "End Date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public virtual Resume Resume { get; set; }
  }
}

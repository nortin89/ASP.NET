namespace HOT4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormalEducation")]
    public partial class FormalEducation
    {
        [Key]
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
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public virtual Resume Resume { get; set; }
    }
}

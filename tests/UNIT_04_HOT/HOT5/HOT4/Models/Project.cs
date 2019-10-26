namespace HOT4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    [Table("Projects")]
    public partial class Project
    {
        [Key]
        public int ProjectId { get; set; }

        
        public int ResumeId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(100)]
        public string TechUsed { get; set; }

        [StringLength(500)]
        public string ProjectDescription { get; set; }

        public virtual Resume Resume { get; set; }
    }
}

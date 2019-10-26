namespace HOT4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skills")]
    public partial class Skill
    {
        [Key]
        public int SkillId { get; set; }

        
        public int ResumeId { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        public int ExperienceLevel { get; set; }


        public virtual Resume Resume { get; set; }
    }
}

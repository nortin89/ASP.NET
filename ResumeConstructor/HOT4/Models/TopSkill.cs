namespace HOT4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TopSkill
    {
        [Key]
        public int ResumeId { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        public int ExperienceLevel { get; set; }


        public virtual Resume Resume { get; set; }
    }
}

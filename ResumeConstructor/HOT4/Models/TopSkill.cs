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
        public int ApplicantId { get; set; }

        [Required]
        [StringLength(100)]
        public string SkillName { get; set; }

        public bool? ExpLevelOptionOne { get; set; }

        public bool? ExpLevelOptionTwo { get; set; }

        public bool? ExpLevelOptionThree { get; set; }

        public bool? ExpLevelOptionFour { get; set; }

        public bool? ExpLevelOptionFive { get; set; }

        public virtual Resume Resume { get; set; }
    }
}

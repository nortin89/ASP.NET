namespace HOT4.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class ResumeConstructorDatabase : DbContext
  {
    public ResumeConstructorDatabase()
        : base("name=ResumeConstructorDatabase")
    {
    }

    public virtual DbSet<FormalEducation> FormalEducations { get; set; }
    public virtual DbSet<PastJob> PastJobs { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ReleventProject> ReleventProjects { get; set; }
    public virtual DbSet<Resume> Resumes { get; set; }
    public virtual DbSet<TopSkill> TopSkills { get; set; }
    public virtual DbSet<ResumePhoto> ResumePhotos { get; set; }
    public virtual DbSet<Photo>Photos { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}

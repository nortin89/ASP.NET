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

    public virtual DbSet<Education> Educations { get; set; }
    public virtual DbSet<Job> Jobs { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Resume> Resumes { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<ResumePhoto> ResumePhotos { get; set; }
    public virtual DbSet<Photo>Photos { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}

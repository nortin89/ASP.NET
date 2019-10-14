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
    public virtual DbSet<MSreplication_options> MSreplication_options { get; set; }
    public virtual DbSet<spt_fallback_db> spt_fallback_db { get; set; }
    public virtual DbSet<spt_fallback_dev> spt_fallback_dev { get; set; }
    public virtual DbSet<spt_fallback_usg> spt_fallback_usg { get; set; }
    public virtual DbSet<spt_monitor> spt_monitor { get; set; }
    public virtual DbSet<ResumePhoto> ResumePhotos { get; set; }
    public virtual DbSet<Photo>Photos { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<FormalEducation>()
          .Property(e => e.SchoolName)
          .IsUnicode(false);

      modelBuilder.Entity<FormalEducation>()
          .Property(e => e.Degree)
          .IsUnicode(false);

      modelBuilder.Entity<FormalEducation>()
          .Property(e => e.Subject)
          .IsUnicode(false);

      modelBuilder.Entity<PastJob>()
          .Property(e => e.CompanyName)
          .IsUnicode(false);

      modelBuilder.Entity<PastJob>()
          .Property(e => e.CompanyAddress)
          .IsUnicode(false);

      modelBuilder.Entity<PastJob>()
          .Property(e => e.ManagerName)
          .IsUnicode(false);

      modelBuilder.Entity<PastJob>()
          .Property(e => e.ManagerPhone)
          .IsUnicode(false);

      modelBuilder.Entity<PastJob>()
          .Property(e => e.Position)
          .IsUnicode(false);

      modelBuilder.Entity<Product>()
          .Property(e => e.Price)
          .HasPrecision(16, 2);

      modelBuilder.Entity<ReleventProject>()
          .Property(e => e.ProjectName)
          .IsUnicode(false);

      modelBuilder.Entity<ReleventProject>()
          .Property(e => e.TechUsed)
          .IsUnicode(false);

      modelBuilder.Entity<ReleventProject>()
          .Property(e => e.ProjectDescription)
          .IsUnicode(false);

      modelBuilder.Entity<Resume>()
          .Property(e => e.FullName)
          .IsUnicode(false);

      modelBuilder.Entity<Resume>()
          .Property(e => e.PhoneNumber)
          .IsUnicode(false);

      modelBuilder.Entity<Resume>()
          .Property(e => e.EmailAddress)
          .IsUnicode(false);

      modelBuilder.Entity<Resume>()
          .HasOptional(e => e.FormalEducation)
          .WithRequired(e => e.Resume);

      modelBuilder.Entity<Resume>()
          .HasOptional(e => e.PastJob)
          .WithRequired(e => e.Resume);

      modelBuilder.Entity<Resume>()
          .HasOptional(e => e.ReleventProject)
          .WithRequired(e => e.Resume);

      modelBuilder.Entity<Resume>()
          .HasOptional(e => e.TopSkill)
          .WithRequired(e => e.Resume);

      modelBuilder.Entity<TopSkill>()
          .Property(e => e.SkillName)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_db>()
          .Property(e => e.xserver_name)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_db>()
          .Property(e => e.name)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_dev>()
          .Property(e => e.xserver_name)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_dev>()
          .Property(e => e.xfallback_drive)
          .IsFixedLength()
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_dev>()
          .Property(e => e.name)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_dev>()
          .Property(e => e.phyname)
          .IsUnicode(false);

      modelBuilder.Entity<spt_fallback_usg>()
          .Property(e => e.xserver_name)
          .IsUnicode(false);
    }
  }
}

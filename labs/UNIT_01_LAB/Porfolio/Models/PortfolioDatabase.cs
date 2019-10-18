namespace Porfolio.Models
{
  using System;
  using System.Data.Entity;
  using System.Linq;

  public class PortfolioDatabase : DbContext
  {

    public PortfolioDatabase()
        : base("name=PortfolioDatabase")
    {
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectPhoto> ProjectPhotos { get; set; }
    public DbSet<ProjectTag> ProjectTags { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
  }


}
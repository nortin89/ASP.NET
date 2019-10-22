using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
  public class PortfolioDatabase : DbContext
  {

    public PortfolioDatabase()
        : base("name=PortfolioDatabase")
    {
    }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<ProjectPhoto> ProjectPhotos { get; set; }
    public virtual DbSet<ProjectTag> ProjectTags { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
  }
}
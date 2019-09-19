namespace Experiment.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class ExperimentDatabase : DbContext
  {
    public ExperimentDatabase()
        : base("name=ExperimentDatabase")
    {
    }

    public virtual DbSet<RosterItem> RosterItems { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
  }
}

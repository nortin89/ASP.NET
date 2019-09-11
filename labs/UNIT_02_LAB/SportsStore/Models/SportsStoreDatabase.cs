namespace SportsStore.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class SportsStoreDatabase : DbContext
  {
    public SportsStoreDatabase()
        : base("name=SportsStoreDatabase")
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>()
          .Property(e => e.Price)
          .HasPrecision(16, 2);
    }
  }
}

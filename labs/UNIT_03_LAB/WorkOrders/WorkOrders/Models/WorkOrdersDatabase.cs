namespace WorkOrders.Models
{
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class WorkOrdersDatabase : DbContext
  {
    public WorkOrdersDatabase()
        : base("name=WorkOrdersDatabase")
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Part> Parts { get; set; }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.ClientName)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.PhoneNumber)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.StreetAddress)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.City)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.State)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Customer>()
    //      .Property(e => e.Zip)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.TechName)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.LicencePlate)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.VehicleYear)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.VehicleMake)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.VehicleModel)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.Mileage)
    //      .IsUnicode(false);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.LaborCostPerHour)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.TotalCostParts)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.TotalCostLabor)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.TotalCostLaborParts)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.TotalTax)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Order>()
    //      .Property(e => e.GrandTotal)
    //      .HasPrecision(10, 2);

    //  modelBuilder.Entity<Part>()
    //      .Property(e => e.PartCost)
    //      .HasPrecision(8, 2);
    //}
  }
}

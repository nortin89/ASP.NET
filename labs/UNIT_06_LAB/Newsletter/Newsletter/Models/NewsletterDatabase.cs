namespace Newsletter.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsletterDatabase : DbContext
    {
        public NewsletterDatabase()
            : base("name=NewsletterDatabase")
        {
        }

        public virtual DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

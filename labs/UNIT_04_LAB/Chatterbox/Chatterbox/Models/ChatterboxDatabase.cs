using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chatterbox.Models
{
  public class ChatterboxDatabase : DbContext
  {
    public ChatterboxDatabase() : base("name =Chatterbox")
    {

    }

    public virtual DbSet<Message> Messages { get; set; }
  }
}
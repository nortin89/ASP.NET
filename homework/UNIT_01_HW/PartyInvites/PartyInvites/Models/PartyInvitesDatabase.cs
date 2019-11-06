namespace PartyInvites.Models
{
  using System;
  using System.Data.Entity;
  using System.Linq;

  public class PartyInvitesDatabase : DbContext
  {

    public PartyInvitesDatabase()
        : base("name=PartyInvitesDatabase")
    {
    }

    public virtual DbSet<GuestResponse> GuestResponses { get; set; }
  }
}
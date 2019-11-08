namespace PartyInvites.Models
{
  using System.Data.Entity;

  public class PartyInviteDatabase : DbContext
  {
    public PartyInviteDatabase()
        : base("name=PartyInviteDatabase")
    {
    }

    public virtual DbSet<GuestResponse> GuestResponses { get; set; }
  }
}
using FluentScheduler;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartyInvites.Models;

namespace PartyInvites.Jobs
{
  public class PartyReminder : IJob, IRegisteredObject
  {
    private PartyInvitesDatabase _db = new PartyInvitesDatabase();

    public PartyReminder()
    {
      HostingEnvironment.RegisterObject(this);
    }

    public void Stop(bool immediate)
    {
      HostingEnvironment.UnregisterObject(this);
    }

    public void Execute()
    {
      try
      {
        Task task = DoWork();
        task.Wait();
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.ToString());
      }
      finally
      {
        HostingEnvironment.UnregisterObject(this);
      }
    }

    private async Task DoWork()
    {
      var responses = new GuestResponse();

      if(responses.WillAttend == true)
      {
        Debug.WriteLine("Newsletter Sent");
      }

      //TODO: implement job

      Debug.WriteLine("Newsletter Sent");
    }
  }
}
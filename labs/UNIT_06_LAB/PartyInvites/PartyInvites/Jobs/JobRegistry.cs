using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PartyInvites.Jobs
{
  public class JobRegistry : Registry
  {
    public JobRegistry()
    {
      Schedule(() => Debug.WriteLine("party tomorrow"))
        .ToRunOnceAt(new DateTime(2019, 11, 6, 15, 35, 0));

      Schedule<PartyReminder>().ToRunNow();

      Debug.WriteLine("JobRegistry Started");
    }
  }
}
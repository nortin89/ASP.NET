using System;
using FluentScheduler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace PartyInvites.Jobs
{
  public class JobRegistry : Registry
  {
    public JobRegistry()
    {
      Schedule(() => Debug.WriteLine("party tomorrow"))
        .ToRunOnceAt(new DateTime(2019, 11, 6, 15, 35, 0));

      Schedule<PartyReminder>()
        .ToRunNow();

      Debug.WriteLine("JobRegistry Started");
    }
  }
}
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Blogger.Jobs
{
  public class JobRegistry : Registry
  {
    public JobRegistry()
    {
      //Schedule(() => Debug.WriteLine("There is a new Blog!!"))
      //  .ToRunOnceAt(new DateTime(2019, 11, 6, 15, 35, 0));

      Schedule<BlogReminder>().ToRunEvery(1).Days().At(16,0);

      Debug.WriteLine("JobRegistry Started");
    }

  }
}
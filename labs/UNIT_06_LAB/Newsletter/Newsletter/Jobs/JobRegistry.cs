namespace Newsletter.Jobs
{
    using FluentScheduler;
    using System;
    using System.Diagnostics;

    public class JobRegistry : Registry
    {
        public JobRegistry()
        {
            Schedule<WeeklyNewsletter>().ToRunNow();
            Schedule<WeeklyNewsletter>().ToRunEvery(1).Weeks().On(DayOfWeek.Monday).At(16, 0);

            Debug.WriteLine("JobRegistry Started");
        }
    }
}
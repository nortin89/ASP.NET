using Blogger.Models;
using FluentScheduler;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace Blogger.Jobs
{
  public class BlogReminder : IJob, IRegisteredObject
  {
    public BlogReminder()
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
      catch (Exception ex)
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

      List<BlogPost> posts;

      List<Subscriber> subscribers;
      using (var db = new BloggerDatabase())
      {
        posts =
          await db.BlogPosts
                  .Where(x => x.Posted.Value.Date == DateTime.Today)
                  .ToListAsync();

        subscribers =
            await db.Subscribers
                    .Where(x => x.IsConfirmed && x.IsSubscribed)
                    .ToListAsync();
      }

      var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
      var client = new SendGridClient(apiKey);

      var from = new EmailAddress("scott_nortin@insideranken.org", "Scott Nortin");
      var subject =
          "Your Blog Reminder is Here!!";
      var plainTextContent =
          "Check out the new Blog post today on Blogger.\n\n\n\n{unsubscribe}";
      var htmlContent =
          "<strong>We missed you! All this weeks goodies are attached.</strong>" +
          "<br><br><a href='{unsubscribe}'>Unsubscribe</a>";

      var substitutions =
        subscribers.Select(x => new Dictionary<string, string>() {
                            { "{name}", x.FullName },
                            { "{email}", x.Email },
                            { "{unsubscribe}", x.UnsubscribeUrl },
                   })
                   .ToList();

      var msg = MailHelper.CreateMultipleEmailsToMultipleRecipients(
          from,
          subscribers.Select(x => new EmailAddress(x.Email, x.FullName)).ToList(),
          subscribers.Select(x => subject).ToList(),
          plainTextContent,
          htmlContent,
          substitutions);
      await client.SendEmailAsync(msg);

      var result = await client.SendEmailAsync(msg);
      if (result.StatusCode != HttpStatusCode.Accepted)
      {
        throw new Exception($"Failed to send email: {result.StatusCode}");
      }

      Debug.WriteLine("Reminder Sent");
    }

  }
}
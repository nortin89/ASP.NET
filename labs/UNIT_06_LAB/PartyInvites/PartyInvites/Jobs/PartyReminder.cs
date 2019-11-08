using FluentScheduler;
using PartyInvites.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace PartyInvites.Jobs
{
  public class PartyReminder : IJob, IRegisteredObject
  {
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
      var db = new PartyInviteDatabase();
      var responses =
        db.GuestResponses
          .Where(x => x.WillAttend == true)
          .ToList();

      var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
      var client = new SendGridClient(apiKey);

      //foreach (var response in responses)
      //{
      //  var from = new EmailAddress("prsmith@ranken.edu", "Paul Smith");
      //  var to = new EmailAddress(response.Email, response.Name);
      //  var subject = "The Big Party is Tomorrow!!";
      //  var body = "Hope to see you Tomorrow!! The party will start at 7PM";

      //  var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
      //  await client.SendEmailAsync(msg);
      //}

      var from = new EmailAddress("prsmith@ranken.edu", "Paul Smith");
      var subject = "The Big Party is Tomorrow!!";
      var body = "Hi {name}. Hope to see you Tomorrow!! The party will start at 7PM";

      var tos =
        responses.Select(x => new EmailAddress(x.Email, x.Name))
                 .ToList();

      var subjects =
        responses.Select(x => subject)
                 .ToList();

      //var substitutions =
      //  responses.Select(x => new Dictionary<string, string>() {
      //              { "{name}", x.Name },
      //              { "{email}", x.Email },
      //              { "{phone}", x.Phone },
      //           })
      //           .ToList();

      var substitutions =
        responses.Select(x => new { name = x.Name, email = x.Email, phone = x.Phone })
                 .ToList<object>();

      //var msg = MailHelper.CreateMultipleEmailsToMultipleRecipients(
      //  from, tos, subjects, body, body, substitutions);
      string templateId = "d-907b3ecfe3a74ffcaf029fb83b8c9411";
      var msg = MailHelper.CreateMultipleTemplateEmailsToMultipleRecipients(
        from, tos, templateId, substitutions);
      await client.SendEmailAsync(msg);

      Debug.WriteLine("The Party is Tomorrow!!");
    }

  }
}
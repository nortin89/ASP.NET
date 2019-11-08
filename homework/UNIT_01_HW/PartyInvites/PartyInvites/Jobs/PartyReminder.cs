using FluentScheduler;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartyInvites.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

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
      var db = new PartyInvitesDatabase();

      var responses = 
        db.GuestResponses.Where(x => x.WillAttend == true)
                        .ToList();

      var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
      var client = new SendGridClient(apiKey);

      //foreach (var response in responses)
      //{

      //}

      var from = new EmailAddress("nortin89@gmail.com", "Scott Nortin");
      //var subject = "The Big Party is Tomorrow!!";
      //var body = "Hi {{name}}. Hope to see you Tomorrow!! The party will start at 7pm";

      //var plainTextContent = "and easy to do anywhere, even with C#";
      //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

      var tos =
        responses.Select(x => new EmailAddress(x.Email, x.Name))
                 .ToList();

      //var subjects = 
      //  responses.Select(x => subject)
      //                        .ToList();

      //var substitutions =
      //  responses.Select(x => new Dictionary<string, string>() {
      //                  {"{name}", x.Name },
      //                  {"{email}",x.Email},
      //                  {"{phone}",x.Phone },
      //              })
      //                             .ToList();

      var substitutions =
                    responses.Select(x => new { name = x.Name, email = x.Email, phone = x.Phone }).ToList<object>();
           

      //var msg = MailHelper.CreateMultipleEmailsToMultipleRecipients(
      //  from, tos, subjects, body, body,substitutions);

      string templateId = "d-9723149833ee41f9a626d0d550ff99a9";
      var msg = MailHelper.CreateMultipleTemplateEmailsToMultipleRecipients(from, tos, templateId, substitutions);

      await client.SendEmailAsync(msg);

      //TODO: implement job

      Debug.WriteLine("The big party is tomorrow");
    }
  }
}
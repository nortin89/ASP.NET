namespace Newsletter.Jobs
{
    using FluentScheduler;
    using Newsletter.Models;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Hosting;

    public class WeeklyNewsletter : IJob, IRegisteredObject
    {
        public WeeklyNewsletter()
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
            List<Subscriber> subscribers;
            using (var db = new NewsletterDatabase())
            {
                subscribers =
                    await db.Subscribers
                            .Where(x => x.IsConfirmed && x.IsSubscribed)
                            .ToListAsync();
            }

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("prsmith@ranken.edu", "Paul Smith");
            var subject =
                "Your Weekly Newsletter is Here!!";
            var plainTextContent =
                "We missed you! All this weeks goodies are attached.\n\n\n\n{unsubscribe}";
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

            Debug.WriteLine("Newsletter Sent");
        }
    }
}
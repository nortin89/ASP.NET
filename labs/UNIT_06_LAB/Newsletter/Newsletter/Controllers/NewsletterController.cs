namespace Newsletter.Controllers
{
    using Newsletter.Models;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class NewsletterController : Controller
    {
        private NewsletterDatabase _db = new NewsletterDatabase();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        // Utility Methods

        private string GetApiKey()
        {
            return Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }

        private EmailAddress GetFromEmail()
        {
            string email = Environment.GetEnvironmentVariable("SENDGRID_FROM_EMAIL") ?? "prsmith@ranken.edu";
            string name = Environment.GetEnvironmentVariable("SENDGRID_FROM_NAME") ?? "Paul Smith";
            return new EmailAddress(email, name);
        }

        // Action Methods

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Subscribe()
        {
            var model = new Subscriber()
            {
                IsConfirmed = false,
                IsSubscribed = false,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Subscribe(Subscriber model)
        {
            // Redisplay the form if the user data is not valid
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please ensure all data is valid.");
                return View(model);
            }

            // Clean the data
            model.FullName = model.FullName.Trim();
            model.Email = model.Email.Trim().ToLower();
            model.IsConfirmed = false;
            model.IsSubscribed = false;
            model.UnsubscribeUrl = Url.Action("Unsubscribe", "Newsletter", new { model.Email }, "https"); // include the protocol to get an absolute path

            try
            {
                // Save the subscriber info to the database
                var dbEntry = await _db.Subscribers.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (dbEntry == null)
                {
                    // New subscriber
                    _db.Subscribers.Add(model);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    // Existing subscriber
                    // don't change the email or status flags
                    dbEntry.FullName = model.FullName;
                    dbEntry.UnsubscribeUrl = model.UnsubscribeUrl;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ModelState.AddModelError("", "Failed to save information to database. Please try again.");
                ModelState.AddModelError("", ex.Message);
            }

            try
            {
                // Send the confirmation email to the subscriber
                var apiKey = GetApiKey();
                var client = new SendGridClient(apiKey);

                var from = GetFromEmail();
                var to = new EmailAddress(model.Email, model.FullName);
                var subject = "Please Confirm Your Email Address";

                var confirmLink = Url.Action("Confirm", "Newsletter", new { model.Email }, "https"); // include the protocol to get an absolute path
                var plainTextContent =
                    "Please follow the link below to confirm your subscription\n\n" + confirmLink;
                var htmlContent =
                    "<strong>Please follow the link below to confirm your subscription</strong>" +
                    $"<br><a href='{confirmLink}'>{confirmLink}</a>";

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var result = await client.SendEmailAsync(msg);
                if (result.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception($"Failed to send email: {result.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ModelState.AddModelError("", "Failed to send confirmation email. Please try again.");
                ModelState.AddModelError("", ex.Message);
            }

            if (ModelState.IsValid)
            {
                // Redirect the user to the Thanks action
                return RedirectToAction("Thanks", new { model.Email });
            }
            else
            {
                // Redisplay the subscribe form, so that users can try again
                return View(model);
            }
        }

        public async Task<ActionResult> Thanks(string email)
        {
            var sub = await _db.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            return View(sub);
        }

        public async Task<ActionResult> Confirm(string email)
        {
            Subscriber sub = null;
            try
            {
                sub = await _db.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
                if (sub == null)
                {
                    ModelState.AddModelError("", "We were unable to find your email address in the database.");
                    return View(sub);
                }

                // Update the database
                sub.IsConfirmed = true;
                sub.IsSubscribed = true;
                sub.UnsubscribeUrl = Url.Action("Unsubscribe", "Newsletter", new { sub.Email }, "https"); // include the protocol to get an absolute path
                await _db.SaveChangesAsync();

                // Send the welcome email to the subscriber
                var apiKey = GetApiKey();
                var client = new SendGridClient(apiKey);

                var from = GetFromEmail();
                var to = new EmailAddress(sub.Email, sub.FullName);
                var subject = "Welcome to the group!";
                var body = "You are now subscribed to the weekly mailing list. See you soon!";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

                var result = await client.SendEmailAsync(msg);
                if (result.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception($"Failed to send email: {result.StatusCode}");
                }

                return View(sub);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ModelState.AddModelError("", "Failed to confirm email. Please try again.");
                ModelState.AddModelError("", ex.Message);
                return View(sub);
            }
        }

        public async Task<ActionResult> Unsubscribe(string email)
        {
            Subscriber sub = null;
            try
            {
                sub = await _db.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
                if (sub == null)
                {
                    ModelState.AddModelError("", "We were unable to find your email address in the database.");
                    return View(sub);
                }

                // Update the database
                sub.IsSubscribed = false;
                await _db.SaveChangesAsync();

                return View(sub);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                ModelState.AddModelError("", "Failed to unsubscribe email. Please try again.");
                ModelState.AddModelError("", ex.Message);
                return View(sub);
            }
        }
    }
}
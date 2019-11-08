using PartyInvites.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites.Controllers
{
  public class HomeController : Controller
  {
    private PartyInviteDatabase _db = new PartyInviteDatabase();

    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult RsvpForm()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> RsvpForm(GuestResponse guestResponse)
    {
      if (!ModelState.IsValid)
      {
        return View("RsvpForm", guestResponse);
      }

      try
      {
        var dbEntry =
          _db.GuestResponses.FirstOrDefault(x => x.Email == guestResponse.Email);

        if (dbEntry == null)
        {
          _db.GuestResponses.Add(guestResponse);
          await _db.SaveChangesAsync();
        }
        else
        {
          dbEntry.Name = guestResponse.Name;
          dbEntry.Phone = guestResponse.Phone;
          dbEntry.WillAttend = guestResponse.WillAttend;
          await _db.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //return View("RsvpForm", guestResponse);
      }

      try
      {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);

        var from = new EmailAddress(guestResponse.Email, guestResponse.Name);
        var to = new EmailAddress("prsmith@ranken.edu", "Paul Smith");
        var subject = "RSVP Notification";
        var body =
          guestResponse.Name + " is "
              + (guestResponse.WillAttend == true ? "" : "not ")
              + "attending";

        //var plainTextContent = "and easy to do anywhere, even with C#";
        //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";

        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
        var response = await client.SendEmailAsync(msg);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
        //return View("Error", ex);
      }

      if (ModelState.IsValid)
      {
        return View("Thanks", guestResponse);
      }
      else
      {
        return View("RsvpForm", guestResponse);
      }
    }
  }
}
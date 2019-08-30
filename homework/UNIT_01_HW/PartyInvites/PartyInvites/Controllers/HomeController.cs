using PartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{

  public class HomeController : Controller
  {
    public ViewResult Index()
    {
      int hour = DateTime.Now.Hour;
      ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
      return View();
    }
    // GET: Home
    //public ActionResult Index()
    //{
    //  return View();
    //}
    //public ViewResult RsvpForm()
    //{
    //  return View();
    //}

    [HttpGet]
    public ActionResult RsvpForm()
    {
      return View();
    }

    [HttpPost]
    public ViewResult RsvpForm(GuestResponse guestResponse)
    {
      if (!ModelState.IsValid)
      {
        return View("RsvpForm", guestResponse);
      }


      try
      {
        // See https://www.siteground.com/kb/google_free_smtp_server/
        // See https://devanswers.co/allow-less-secure-apps-access-gmail-account/

        using (SmtpClient smtp = new SmtpClient())
        {
          string host = Environment.GetEnvironmentVariable("SMTP_HOST");
          string port = Environment.GetEnvironmentVariable("SMTP_PORT");
          string user = Environment.GetEnvironmentVariable("SMTP_USER");
          string pass = Environment.GetEnvironmentVariable("SMTP_PASSWORD");

          smtp.Host = host;
          smtp.Port = int.Parse(port);
          smtp.EnableSsl = true;
          smtp.UseDefaultCredentials = false;
          smtp.Credentials = new NetworkCredential(user, pass);

          using (MailMessage message = new MailMessage())
          {
            message.From = new MailAddress(user);
            message.To.Add(new MailAddress(user));
            message.Subject = "RSVP Notification";
            message.Body =
              guestResponse.Name + " is "
              + (guestResponse.WillAttend == true ? "" : "not ")
              + "attending";

            smtp.Send(message);
          }
        }

        return View("Thanks", guestResponse);
      }
      catch (Exception ex)
      {
        return View("Error", ex);
      }
    }
  }
}
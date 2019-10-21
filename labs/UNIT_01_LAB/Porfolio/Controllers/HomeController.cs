using Porfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Porfolio.Controllers
{
  public class HomeController : Controller
  {
    private PortfolioDatabase _db = new PortfolioDatabase();


    // GET: Home
    [HttpGet]
    public ActionResult Index()
    {
      List<ProjectViewModel> projects = _db.Projects.Select(x => new ProjectViewModel
      {
        ProjectID = x.ProjectId,
        Name = x.Name,
        Description = x.Description
      }).ToList();

      ViewBag.Projects = projects;
      return View();
    }


    [HttpPost]
    public ActionResult ContactReply(Contacts contacts)
    {
      if (!ModelState.IsValid)
      {
        return View("Index", contacts);
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
            message.Subject = "User Contact Info";
            message.Body = "Thank You " +
              contacts.Name;

            smtp.Send(message);
          }
        }

        return View("Index", contacts);
      }
      catch (Exception ex)
      {
        return View("Error", ex);
      }
    }
  }
}
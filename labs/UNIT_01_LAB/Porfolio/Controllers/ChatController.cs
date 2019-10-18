using Porfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Message = Porfolio.Models.Message;

namespace Porfolio.Controllers
{
  public class ChatController : Controller
  {
    private PortfolioDatabase _db = new PortfolioDatabase();

    public ActionResult Index(string user)
    {
      ViewBag.user = user;
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> GetMessages(
      int page = 1,
      int pageSize = 100)
    {
      var messages =
        await _db.Messages

            .OrderByDescending(x => x.Sent)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

      var messagesFormatted =
        messages.Select(x => new
        {
          x.Id,
          x.User,
          x.Text,
          Sent = x.Sent.Value.ToString("HH:mm")
        });

      return Json(messagesFormatted);
    }

    [HttpPost]
    public async Task<ActionResult> SendMessage(string user, string text)
    {
      var msg = new Message
      {
        Id = Guid.NewGuid(),
        User = user,
        Text = text,
        Sent = DateTime.Now
      };

      try
      {
        _db.Messages.Add(msg);
        await _db.SaveChangesAsync();
        return Json(new { Success = true, Message = "Message Sent" });
      }
      catch (Exception ex)
      {
        Debug.WriteLine("ERROR: " + ex.Message);
        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
      }

    }
  }
}
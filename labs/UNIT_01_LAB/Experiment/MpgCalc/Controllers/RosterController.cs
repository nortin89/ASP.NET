using MpgCalc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MpgCalc.Controllers
{
  public class RosterController : Controller
  {
    // GET: Roster
    public ActionResult Index()
    {
      var roster = new Roster()
      {
        Items = new List<RosterItem> {
                new RosterItem{FirstName = "Bob", LastName = "Dole", Email= "bobdole@gmail.com"},
                new RosterItem{FirstName = "Scott", LastName = "Nortin", Email= "nortin89@gmail.com"},
                new RosterItem{FirstName = "Esten", LastName = "Kirby", Email= "kirby99@gmail.com"},
                new RosterItem{FirstName = "Caleb", LastName = "G", Email= "calebB@gmail.com"}
        }
      };
      return View(roster);
    }
  }
}
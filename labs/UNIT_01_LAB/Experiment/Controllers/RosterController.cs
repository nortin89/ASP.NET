using Experiment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experiment.Controllers
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

    public ActionResult Add(Roster roster)
    {
      return View(roster);
    }
  }
}
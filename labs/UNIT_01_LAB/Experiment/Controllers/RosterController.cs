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
    private ExperimentDatabase _db = new ExperimentDatabase();

    public ActionResult Index()
    {
      Roster roster = new Roster()
      {
        Items = _db.RosterItems.ToList()
      };
      return View(roster);
    }

    [HttpGet]
    public ActionResult Add()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Add(RosterItem item)
    {
      if (!ModelState.IsValid)
      {
        return View("Add", item);
      }

      _db.RosterItems.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
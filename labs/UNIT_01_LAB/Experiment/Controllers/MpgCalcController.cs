using Experiment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experiment.Controllers
{
    public class MpgCalcController : Controller
    {
      // GET: MpgCalc
      [HttpGet]
      public ActionResult Index()
      {
        //MpgCalcModel model = new MpgCalcModel();
        //model.MilesDriven = 200;

        return View();
      }

      [HttpPost]
      public ActionResult Index(MpgCalcModel model)
      {
        if (!ModelState.IsValid)
        {
          return View("Index", model);
        }

        model.Mpg = model.MilesDriven / model.GallonsUsed;
        model.TripCost = model.GallonsUsed * model.PricePerGallon;
        model.CostPerMile = model.TripCost / model.MilesDriven;
        return View("Index", model);
      }
    }
}
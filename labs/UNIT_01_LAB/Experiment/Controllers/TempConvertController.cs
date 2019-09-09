using Experiment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experiment.Controllers
{
    public class TempConvertController : Controller
    {
    // GET: TempConvert
    [HttpGet]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(TempInput temp)
    {
      ViewBag.UserTemp = temp.Fahrenheit;
      ViewBag.celTemp = (temp.Fahrenheit - 32) / (1.8);
      ViewBag.kelTemp = (ViewBag.celTemp + 273.15);

      return View("Index");
    }
  }
}
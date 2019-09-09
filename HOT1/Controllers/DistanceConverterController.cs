using HOT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOT1.Controllers
{
    public class DistanceConverterController : Controller
    {
        // GET: DistanceConverter
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    [HttpPost]
    public ActionResult Index(DistanceConverter convert)
    {
      ViewBag.IN_PER_CM = convert.DistanceInInches;
      ViewBag.CM_PER_IN = (convert.DistanceInInches * 2.54);

      return View("Index");
    }


  }
}
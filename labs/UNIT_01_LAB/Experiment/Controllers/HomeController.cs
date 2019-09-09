using System.Web.Mvc;

namespace Experiment.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      return View();
    }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
  public class SlowOperationController : Controller
  {
    public async Task<long?> Index()
    {
      var client = new HttpClient();
      var httpMessage = await client.GetAsync("http://apress.com");

      return httpMessage.Content.Headers.ContentLength;
    }
  }
}
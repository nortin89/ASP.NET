using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; //needed for ToListAsync and CountAsync

namespace SportsStore.Controllers
{
  public class ProductController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    // p. 164
    public async Task<ActionResult> List(int page = 1,
      int pageSize = 4,
      string category = null)
    {
      List<Product> products =
        await _db.Products
              .Where(x=> category == null ||x.Category == category)
              .OrderBy(x => x.Name)
              .Skip((page - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();

      int count =
        await _db.Products
              .Where(x => category == null || x.Category == category)
              .CountAsync();

      var model = new ProductListViewModel
      {
        Products = products,
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = count
        },
        CurrentCategory = category
      };

      return View(model);
    }
  }
}
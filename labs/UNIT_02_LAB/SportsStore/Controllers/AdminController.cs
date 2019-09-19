using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
  [Authorize]
  public class AdminController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    public ActionResult Index()
    {
      return View(_db.Products);
    }

    [HttpGet]
    public ActionResult Create()
    {
      return View("Edit",new Product());
    }

    [HttpGet]
    public ActionResult Edit(int productId)
    {
      Product product = _db.Products.SingleOrDefault(x => x.ProductID == productId);
      return View("Edit", product);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Product product)
    {
      if (!ModelState.IsValid)
      {
        return View("Edit", product);
      }
      else if(product.ProductID == 0)
      {
        //Create New Product
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        TempData["message"] = $"{product.Name} has been saved";
        return RedirectToAction("Index");
      }
      else
      {
        //Edit Existing Product
        Product dbEntry = _db.Products.SingleOrDefault(x => x.ProductID == product.ProductID);
        dbEntry.Name = product.Name;
        dbEntry.Description = product.Description;
        dbEntry.Price = product.Price;
        dbEntry.Category = product.Category;
        await _db.SaveChangesAsync();
        TempData["message"] = $"{product.Name} has been updated";
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<ActionResult> Delete(int productId)
    {
      Product product = _db.Products.SingleOrDefault(x => x.ProductID == productId);
      if(product != null)
      {
        _db.Products.Remove(product);
        await _db.SaveChangesAsync();
        TempData["message"] = $"{product.Name} has been deleted";

      }
      return RedirectToAction("Index");
    }
  }
}
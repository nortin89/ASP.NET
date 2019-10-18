using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public async Task<ActionResult> Index()
    {
      var products = await _db.Products.ToListAsync();
      return View(products);
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
      await PopulatePhotoDropdown();

      Product product = new Product();
      product.Photos = new List<ProductPhoto>();
      while(product.Photos.Count < 3)
      {
        product.Photos.Add(new ProductPhoto());
      }

      return View("Edit",new Product());
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int productId)
    {
      Product product = await _db.Products.SingleOrDefaultAsync(x => x.ProductID == productId);

      if(product.Photos == null)
      {
        product.Photos = new List<ProductPhoto>();
      }
      while(product.Photos.Count < 3)
      {
        product.Photos.Add(new ProductPhoto() { ProductID = product.ProductID });
      }

      await PopulatePhotoDropdown();
      return View("Edit", product);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Product product)
    {
      var duplicateProduct = await _db.Products.FirstOrDefaultAsync(x => x.Name == product.Name);
      if (duplicateProduct != null)
      {
        ModelState.AddModelError("Name", "That name is already in use.");
      }

      if (!ModelState.IsValid)
      {
        await PopulatePhotoDropdown();
        return View("Edit", product);
      }
      else if (product.ProductID == 0)
      {
        //Create New Product
        _db.Products.Add(product);

        for (int i = product.Photos.Count - 1; i >= 0; --i) 
        {
          if(product.Photos[i].PhotoId != null)
          {
            product.Photos[i].Product = product;
            _db.ProductPhotos.Add(product.Photos[i]);
          }
          else
          {
            product.Photos.RemoveAt(i);
          }
        }

        await _db.SaveChangesAsync();
        TempData["message"] = $"{product.Name} has been inserted";
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
        dbEntry.Tags = product.Tags;

        //Remove items from the model that do not have a photo selected
        for(int i = product.Photos.Count - 1; i >= 0; --i)
        {
          if(product.Photos[i].PhotoId == null)
          {
            product.Photos.RemoveAt(i);
          }
        }

        //Add new photos
        var photosToAdd = new List<ProductPhoto>();
        foreach (var photo in product.Photos)
        {
          if(!dbEntry.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToAdd.Add(photo);
          }
        }
        _db.ProductPhotos.AddRange(photosToAdd);

        //Remove existing photos
        var photosToRemove = new List<ProductPhoto>();
        foreach (var photo in dbEntry.Photos)
        {
          if (!product.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToRemove.Add(photo);
          }
        }
        _db.ProductPhotos.RemoveRange(photosToAdd);


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

    private async Task PopulatePhotoDropdown()
    {
      List<Photo> photos = 
        await _db.Photos
        .OrderBy(x => x.ImageName)
        .ToListAsync();

      ViewBag.PhotoId = photos; //new SelectList(photos, "PhotoId","ImageName");
    }

    public async Task<ActionResult> GetProductByName(string name)
    {
      var product =
        await _db.Products
                 .Select(x => new { x.ProductID, x.Name })
                 .FirstOrDefaultAsync(x => x.Name == name);

      return Json(product != null ? (object)product : false);
    }
  }
}
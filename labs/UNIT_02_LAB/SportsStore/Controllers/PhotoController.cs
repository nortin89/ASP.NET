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
  public class PhotoController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    public async Task<ActionResult> Index()
    {
      var photos = await _db.Photos.ToListAsync();
      return View(photos);
    }

    [HttpGet]
    public ActionResult Upload()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Upload(Photo photo, HttpPostedFileBase image = null)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      if (image == null)
      {
        ModelState.AddModelError("ImageData", "Image file is required");
        return View();
      }
      else
      {
        photo.ImageMimeType = image.ContentType;
        photo.ImageData = new byte[image.ContentLength];
        image.InputStream.Read(photo.ImageData, 0, image.ContentLength);

        _db.Photos.Add(photo);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
      }
    }

    public async Task<ActionResult> GetImage(int photoId)
    {
      var photo =
        await _db.Photos.SingleOrDefaultAsync(x => x.PhotoId == photoId);

      if (photo != null)
      {
        return File(photo.ImageData, photo.ImageMimeType);
      }
      else
      {
        return null;
      }
    }
  }
}
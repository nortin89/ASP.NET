using HOT4;
using HOT4.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HOT4.Controllers
{
  public class ResumeController : Controller
  {
    private ResumeConstructorDatabase _db = new ResumeConstructorDatabase();

    public async Task<ActionResult> Index(
      int page = 1,
      int pageSize = 3,
      string q = null)
    {
      var resume = await _db.Resumes
        .Include("Skills")
        .Include("Projects")
        .Where(x => q == null ||
        x.FullName.Contains(q) ||
        x.PhoneNumber.Contains(q) ||
        x.EmailAddress.Contains(q))
        .OrderByDescending(x => x.ResumeId)
        .ThenByDescending(x => x.FullName)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

      var count =
      await _db.Resumes
      .Where(x => q == null ||
      x.FullName.Contains(q) ||
      x.PhoneNumber.Contains(q) ||
      x.EmailAddress.Contains(q))
      .CountAsync();

      ViewBag.PagingInfo = new PagingInfo
      {
        CurrentPage = page,
        ItemsPerPage = pageSize,
        TotalItems = count,
      };

      ViewBag.Query = q;

      return View(resume);
    }

    [HttpGet]
    public async Task<ActionResult> Create()
    {
      await PopulatePhotoDropdown();

      var resume = new Resume();
      resume.LastUpdate = DateTime.Now;
      resume.Photos = new List<ResumePhoto>();

      while(resume.Photos.Count < 1)
      {
        resume.Photos.Add(new ResumePhoto());
      }
      //await _db.SaveChangesAsync();
      return View("Edit", resume);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Resume resume)
    {
      //Create New Resume
      resume.LastUpdate = DateTime.Now;
      _db.Resumes.Add(resume);

      for (int i = resume.Photos.Count - 1; i >= 0; --i)
      {
        if (resume.Photos[i].PhotoId != null)
        {
          resume.Photos[i].Resume = resume;
          _db.ResumePhotos.Add(resume.Photos[i]);
        }
        else
        {
          resume.Photos.RemoveAt(i);
        }
      }

      await _db.SaveChangesAsync();
      TempData["message"] = $"{resume.ResumeId} has been inserted";
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<ActionResult> Edit(int resumeId)
    {
      Resume resume =
        await _db.Resumes.SingleOrDefaultAsync(x => x.ResumeId == resumeId);

      if(resume.Photos == null)
      {
        resume.Photos = new List<ResumePhoto>();
      }
      while(resume.Photos.Count < 1)
      {
        resume.Photos.Add(new ResumePhoto() { ResumeId = resume.ResumeId });
      }

      await PopulatePhotoDropdown();
      return View("Edit", resume);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(Resume resume)
    {
      var duplicateResume =
        await _db.Resumes.FirstOrDefaultAsync(x => x.FullName == resume.FullName);

      if(duplicateResume != null)
      {
        ModelState.AddModelError("FullName", "That name is already in use.");
      }

      if (!ModelState.IsValid)
      {
        await PopulatePhotoDropdown();
        return View("Edit", resume);
      }
      else
      {
        //Edit Existing Resume
        Resume dbEntry = _db.Resumes.SingleOrDefault(x => x.ResumeId == resume.ResumeId);
        dbEntry.FullName = resume.FullName;
        dbEntry.PhoneNumber = resume.PhoneNumber;
        dbEntry.EmailAddress = resume.EmailAddress;
        dbEntry.LinkedIn = resume.LinkedIn;
        dbEntry.Skills = resume.Skills;
        dbEntry.Projects = resume.Projects;
        dbEntry.Educations = resume.Educations;

        //Remove items from the model that do not have a photo selected
        for (int i = resume.Photos.Count - 1; i >= 0; --i)
        {
          if (resume.Photos[i].PhotoId == null)
          {
            resume.Photos.RemoveAt(i);
          }
        }

        //Add new photos
        var photosToAdd = new List<ResumePhoto>();
        foreach(var photo in resume.Photos)
        {
          if (!dbEntry.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToAdd.Add(photo);
          }
        }
        _db.ResumePhotos.AddRange(photosToAdd);

        //Remove existing photos
        var photosToRemove = new List<ResumePhoto>();
        foreach (var photo in dbEntry.Photos)
        {
          if (!resume.Photos.Any(x => x.PhotoId == photo.PhotoId))
          {
            photosToRemove.Add(photo);
          }
        }
        _db.ResumePhotos.RemoveRange(photosToAdd);


        await _db.SaveChangesAsync();
        TempData["message"] = $"{resume.ResumeId} has been updated";
        return RedirectToAction("Index");
      }
    }

    private async Task PopulatePhotoDropdown()
    {
      List<Photo> photos =
        await _db.Photos
        .OrderBy(x => x.ImageName)
        .ToListAsync();

      ViewBag.PhotoId = photos;
    }

    public async Task<ActionResult> View(int resumeId)
    {
      var resume =
        await _db.Resumes.SingleOrDefaultAsync(x => x.ResumeId == resumeId);

      return View("View", resume);
    }

    public async Task<ActionResult> GetResumeByName(string name)
    {
      var resume =
        await _db.Resumes
                 .Select(x => new { x.ResumeId, x.FullName })
                 .FirstOrDefaultAsync(x => x.FullName == name);

      return Json(resume != null ? (object)resume : false);
    }
  }
}
using HOT4.HtmlHelpers;
using HOT4.Models;
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
        .Where(x => q == null ||
        x.FullName.Contains(q) ||
        x.PhoneNumber.Contains(q) ||
        x.EmailAddress.Contains(q))
        .OrderByDescending(x => x.ApplicantId)
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
    public async Task<ActionResult> CreateResume()
    {
      var resume = new Resume();
      resume.LastUpdate = DateTime.Now;
      resume.Photos = new List<ResumePhoto>();

      while(resume.Photos.Count < 3)
      {
        resume.Photos.Add(new ResumePhoto());
      }

      return View("Index", resume);
    }

    public async Task<ActionResult> View(int applicantId)
    {
      var resume =
        await _db.Resumes.SingleOrDefaultAsync(x => x.ApplicantId == applicantId);

      return View("View", resume);
    }
  }
}
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; //needed for ToListAsync and CountAsync
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SportsStore.Controllers
{
  public class ProductController : Controller
  {
    private SportsStoreDatabase _db = new SportsStoreDatabase();

    // p. 164
    public async Task<ActionResult> List(
      int page = 1,
      int pageSize = 4,
      string category = null,
      string q = null)
    {

      //_db.Database.Log = msg => Trace.WriteLine(msg);

      //Get all the data needed from the tables
      // joins and .Include() calls should go here
      IQueryable<Product> query = _db.Products;

      //Build the WHERE clause
      if (!string.IsNullOrWhiteSpace(category))
      {
        query = query.Where(x => x.Category == category);
      }
      if (!string.IsNullOrWhiteSpace(q))
      {
        string[] keywords = Regex.Split(q, @"\s+");
        foreach (string word in keywords)
        {
          query = query.Where(x => x.Name.Contains(word) ||
                                   x.Tags.Contains(word) ||
                                   x.Description.Contains(word) ||
                                   x.Category.Contains(word));
        }
      }

      //COunt the total number of items in the result set
      int totalCount = await query.CountAsync();

      //Download a single page of results
      //Remember to always include an ORDER BY clause
      List<Product> products =
        await query.OrderBy(x => x.Name)
                    .ThenBy(x => x.ProductID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToListAsync();



      //var viewModel = new.ProductListViewModel

      //List<Product> products =
      //  await _db.Products
      //        .Where(x=> category == null ||x.Category == category)
      //        .Where(x => q == null ||
      //                x.Name.Contains(q) ||
      //                x.Tags.Contains(q) ||
      //                x.Description.Contains(q))
      //        .OrderBy(x => x.Name)
      //        .Skip((page - 1) * pageSize)
      //        .Take(pageSize)
      //        .ToListAsync();

      //int count =
      //  await _db.Products
      //        .Where(x => category == null || x.Category == category)
      //        .CountAsync();

      //Build the View model and return it
      var model = new ProductListViewModel
      {
        Products = products,
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = totalCount
        },
        CurrentCategory = category,
        Query = q
      };

      return View(model);
    }

    public async Task<ActionResult> Keywords(string term)
    {
      term = term.ToLower();

      var categories = 
        await _db.Products
                 .Where(x => x.Category.Contains(term))
                 .Select(x => x.Category.ToLower())
                 .Distinct()
                 .ToListAsync();

      var tags = await _db.Products
                          .Where(x => x.Tags.Contains(term))
                          .Select(x => x.Tags.ToLower())
                          .Distinct()
                          .ToListAsync();

      var splitTags =
        tags.SelectMany(x => Regex.Split(x, @"\s*,\s*"))
            .Where(x => x.Contains(term));

      var serverDir = Server.MapPath("~/");
      var spelling = new NHunspell.Hunspell(serverDir + "en_US.aff", serverDir + "sportsstore.dic");
      var suggestions =
        spelling.Spell(term) ?
        new List<string>() { term } :
        spelling.Suggest(term).Take(5);

      var results = 
        categories.Union(splitTags)
                  .OrderBy(x => x)
                  .Distinct();

      //results =  results.Union(suggestions);

      results = suggestions.Union(results);

      return Json(results, JsonRequestBehavior.AllowGet);
    }
  }
}
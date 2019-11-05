using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WorkOrders.HtmlHelpers;
using WorkOrders.Models;

namespace WorkOrders.Controllers
{

  public class OrderController : Controller
  {
    private WorkOrdersDatabase _db = new WorkOrdersDatabase();

    public async Task<ActionResult> Index(
      int page = 1,
      int pageSize = 3,
      int? orderNumber = null,
      string clientName = null,
      DateTime? startDate = null,
      DateTime? endDate = null)
    {
      IQueryable<Order> query = _db.Orders;

      //Build the WHERE clause
      if (orderNumber != null)
      {
        query = query.Where(x => x.OrderNumber == orderNumber);
      }
      if (!string.IsNullOrWhiteSpace(clientName))
      {
        string[] keywords = Regex.Split(clientName, @"\s+");
        foreach (string word in keywords)
        {
          query = query.Where(x => x.Customer.ClientName.Contains(word));
        }
      }

      //Count the total number of items in the result set
      int totalCount = await query.CountAsync();

      //Download a single page of results
      //Remember to always include an ORDER BY clause
      List<Order> orders =
        await query.OrderBy(x => x.Customer.ClientName)
                   .ThenBy(x => x.OrderNumber)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize).ToListAsync();

      var model = new OrderListViewModel
      {
        Orders = orders,
        PagingInfo = new PagingInfo
        {
          CurrentPage = page,
          ItemsPerPage = pageSize,
          TotalItems = totalCount
        },
        ClientName = clientName,
        OrderNumber = orderNumber,
        StartDate = startDate,
        EndDate = endDate
      };

      return View(model);
    }

    public async Task<ActionResult> ClientNames(string term)
    {
      term = term.ToLower();

      var clientNames =
        await _db.Orders
                 .Where(x => x.Customer.ClientName.Contains(term))
                 .Select(x => x.Customer.ClientName.ToLower())
                 .Distinct()
                 .ToListAsync();

      var serverDir = Server.MapPath("~/");

      var spelling = new NHunspell.Hunspell(
        serverDir + "en_US.aff",
        serverDir + "names.dic");

      var suggestions =
        spelling.Spell(term) ?
        new List<string>() { term } :
        spelling.Suggest(term).Take(5);

      var results =
                   clientNames
                  .OrderBy(x => x)
                  .Distinct();

      results = suggestions.Union(results);

      return Json(results, JsonRequestBehavior.AllowGet);
    }

    public async Task<ActionResult> View(int orderId)
    {
      var order =
        await _db.Orders.SingleOrDefaultAsync(x => x.OrderId == orderId);

      return View("View", order);
    }

    [HttpGet]
    public ActionResult Start()
    {
      var order = new Order();
      order.Customer = new Customer();
      order.RepairDate = DateTime.Now;

      //_db.SaveChanges();
      //TempData["message"] = $"{order.OrderNumber} has been inserted";
      return View("Start", order);
    }

    [HttpPost]
    public async Task<ActionResult> Start(Order order)
    {
      //Create new Order
      order.RepairDate = DateTime.Now;
      _db.Orders.Add(order);

      await _db.SaveChangesAsync();
      TempData["message"] = $"Order # {order.OrderNumber} has been inserted";
      return RedirectToAction("Index");

      //if (!ModelState.IsValid)
      //{
      //  return View("Start", order);
      //}
      //else if (order.OrderId == 0)
      //{

      //}
      //else
      //{
      //  //Edit existing Order
      //  var dbEntry = _db.Orders.SingleOrDefault(x => x.OrderId == order.OrderId);
      //  dbEntry.OrderNumber = order.OrderNumber;
      //  dbEntry.Customer.ClientName = order.Customer.ClientName;
      //  dbEntry.TechName = order.TechName;
      //  dbEntry.RepairDate = order.RepairDate;
      //  dbEntry.VehicleYear = order.VehicleYear;
      //  dbEntry.VehicleMake = order.VehicleMake;
      //  dbEntry.VehicleModel = order.VehicleModel;
      //  dbEntry.Mileage = order.Mileage;

      //  await _db.SaveChangesAsync();
      //  TempData["message"] = $"{order.OrderNumber} has been updated";
      //  return RedirectToAction("Index");
      //}
    }

    [HttpPost]
    public async Task<ActionResult> AddPart(Part part)
    {
      _db.Parts.Add(part);
      await _db.SaveChangesAsync();

      TempData["message"] = $"{part.PartNumber} has been added.";
      return RedirectToAction("View", new { OrderId = part.OrderId });
    }

    [HttpPost]
    public async Task<ActionResult> DeletePart(int partId)
    {
      Part part = _db.Parts.SingleOrDefault(x => x.PartId == partId);

      _db.Parts.Remove(part);
      await _db.SaveChangesAsync();

      TempData["message"] = $"{part.PartNumber} has been deleted";
      return RedirectToAction("View", new { OrderId = part.OrderId });
    }
  }
}
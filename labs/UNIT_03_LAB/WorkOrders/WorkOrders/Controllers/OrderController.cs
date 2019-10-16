using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
      var order = await _db.Orders
        .Where(x => orderNumber == null || x.OrderNumber == orderNumber)
        .Where(x => startDate == null || x.RepairDate  >= startDate )
        .Where(x => clientName == null || x.Customer.ClientName.Contains(clientName))
        .Where(x => endDate == null || x.RepairDate <= endDate )
        .OrderByDescending(x => x.RepairDate)
        .ThenByDescending(x => x.Customer.ClientName)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

      var count =
        await _db.Orders
        .CountAsync();
        

      ViewBag.PagingInfo = new PagingInfo
      {
        CurrentPage = page,
        ItemsPerPage = pageSize,
        TotalItems = count,
      };

      return View(order);
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

      return View("Start", order);
    }

    [HttpPost]
    public async Task<ActionResult> Start(Order order)
    {
      if (!ModelState.IsValid)
      {
        return View("Start", order);
      }
      else if (order.OrderId == 0)
      {
        //Create new Order
        order.RepairDate = DateTime.Now;
        _db.Orders.Add(order);

        await _db.SaveChangesAsync();
        TempData["message"] = $"Order # {order.OrderNumber} has been inserted";
        return RedirectToAction("Index");
      }
      else
      {
        //Edit existing Order
        var dbEntry = _db.Orders.SingleOrDefault(x => x.OrderId == order.OrderId);
        dbEntry.OrderNumber = order.OrderNumber;
        dbEntry.Customer.ClientName = order.Customer.ClientName;
        dbEntry.TechName = order.TechName;
        dbEntry.RepairDate = order.RepairDate;
        dbEntry.VehicleYear = order.VehicleYear;
        dbEntry.VehicleMake = order.VehicleMake;
        dbEntry.VehicleModel = order.VehicleModel;
        dbEntry.Mileage = order.Mileage;

        await _db.SaveChangesAsync();
        TempData["message"] = $"{order.OrderNumber} has been updated";
        return RedirectToAction("Index");

      }
    }


  }
}
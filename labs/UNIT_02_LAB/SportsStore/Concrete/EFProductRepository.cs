using SportsStore.Abstract;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Concrete
{
  public class EFProductRepository : IProductRepository
  {
    private EFDbContext context = new EFDbContext();

    public IEnumerable<Product> Products
    {
      get { return context.Products; }
    }
  }
}
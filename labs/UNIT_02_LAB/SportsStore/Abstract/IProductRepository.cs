using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Abstract
{
  interface IProductRepository
  {
    IEnumerable<Product> Products { get; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
  public class CartLine
  {
    public Product Product { get; set; }
    public int Quantity { get; set; }
  }

  public class Cart
  {
    private List<CartLine> _lines = new List<CartLine>();

    public bool IsEmpty
    {
      get { return _lines.Count == 0; }
    }

    public IEnumerable<CartLine> Lines
    {
      get { return _lines; }
    }

    public void Add(Product product,int quantity)
    {
      //FIXME: prevent duplicate products
      CartLine line = _lines.SingleOrDefault(x => x.Product.ProductID == product.ProductID);
      if(line == null)
      {
        _lines.Add(new CartLine { Product = product, Quantity = quantity });
      }
      else
      {
        line.Quantity += quantity;
      }

      //_lines.Add(new CartLine { Product = product, Quantity = quantity });
    }
    public void Remove(Product product)
    {
      _lines.RemoveAll(x => x.Product.ProductID == product.ProductID);
    }

    public decimal ComputeTotalValue()
    {
      return _lines.Sum(e => (e.Product.Price ?? 0)* e.Quantity);
    }

    public void Clear()
    {
      _lines.Clear();
    }
  }
}
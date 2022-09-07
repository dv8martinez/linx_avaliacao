using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Models
{
  public class ResponseModel<T> where T : class
  {
    public ResponseModel()
    {
      Items = new List<T>();
    }
    public ResponseModel(T item)
    {
      Item = item;

    }
    public ResponseModel(List<T> items)
    {
      Items = items;
    }
    public T Item { get; private set; }
    public List<T> Items { get; private set; }
    public int Quantity => Item != null ? 1 : Items == null ? 0 : Items.Count;
  }
}

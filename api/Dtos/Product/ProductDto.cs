using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
  public class ProductDto
  {
    public int Id { get; set; }

    public int? ShopId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public double Price { get; set; }

    public bool IsAvailable { get; set; }
  }
}
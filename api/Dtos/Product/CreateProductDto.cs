using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
  public class CreateProductDto
  {
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public bool IsAvailable { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;

namespace api.Dtos.Shop
{
  public class ShopDto
  {
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<ProductDto> Products { get; set; }
  }
}
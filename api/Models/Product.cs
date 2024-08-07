using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Product
  {
    public int Id { get; set; }

    public int? ShopId { get; set; }

    public Shop? Shop { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public double Price { get; set; }
    // [Column(TypeName = "decimal(18,2)")]

    public bool IsAvailable { get; set; }

  }
}
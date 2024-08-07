using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Shop
  {
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty; // avoid null reference error

    public string Location { get; set; } = string.Empty;

    // piljarnica, prod baterija, elektronike...
    public string Industry { get; set; } = string.Empty;

    // supermarket, minimarket etc...
    public string Type { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new List<Product>();
  }
}
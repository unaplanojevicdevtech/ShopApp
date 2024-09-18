using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Shop
{
  public class CreateShopDto
  {
    [Required]
    [MaxLength(15, ErrorMessage = "CompanyName cannot have more than 15 characters")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [MinLength(5, ErrorMessage = "Name must contain at least 5 characters")]
    public string Location { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
  }
}
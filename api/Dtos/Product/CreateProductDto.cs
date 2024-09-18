using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
  public class CreateProductDto
  {
    [Required]
    [MinLength(3, ErrorMessage = "Name must contain at least 3 characters")]
    [MaxLength(280, ErrorMessage = "Name cannot have more than 280 characters")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(1, 100000)]
    public double Price { get; set; }
    [Required]
    public bool IsAvailable { get; set; }
  }
}
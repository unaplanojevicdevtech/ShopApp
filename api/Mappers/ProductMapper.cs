using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
  public static class ProductMapper
  {
    public static ProductDto ToProductDto(this Product productModel)
    {
      return new ProductDto
      {
        Id = productModel.Id,
        ShopId = productModel.ShopId,
        Name = productModel.Name,
        Category = productModel.Category,
        Price = productModel.Price,
        IsAvailable = productModel.IsAvailable
      };
    }

    public static Product ToProductFromCreate(this CreateProductDto productModel, int shopId)
    {
      return new Product
      {
        ShopId = shopId,
        Name = productModel.Name,
        Price = productModel.Price,
      };
    }
  }
}
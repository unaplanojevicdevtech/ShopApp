using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Shop;
using api.Models;

namespace api.Mappers
{
  public static class ShopMapper
  {
    public static ShopDto ToShopDto(this Shop shopModel) 
    {
      return new ShopDto
      {
        Id = shopModel.Id,
        CompanyName = shopModel.CompanyName,
        Location = shopModel.Location,
        Industry = shopModel.Industry,
        Type = shopModel.Type,
        Products = shopModel.Products.Select(p => p.ToProductDto()).ToList()
      };
    }

    public static Shop ToShopFromCreateDto(this CreateShopDto shopDto)
    {
      return new Shop{
        CompanyName = shopDto.CompanyName,
        Location = shopDto.Location,
        Industry = shopDto.Industry,
        Type = shopDto.Type
      };
    }
  }
}
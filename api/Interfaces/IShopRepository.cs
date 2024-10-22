using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Shop;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
  public interface IShopRepository
  {
    Task<List<Shop>> GetAllAsync(QueryObject query);
    Task<Shop?> GetByIdAsync(int id);
    Task<Shop> CreateAsync(Shop shop);
    Task<Shop?> UpdateAsync(int id, CreateShopDto shop);
    Task<Shop?> DeleteAsync(int id);
    Task<bool> ShopExists(int id);
  }
}

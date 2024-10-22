using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Shop;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ShopRepository : IShopRepository
  {
    private readonly ApplicationDBContext _context;
    public ShopRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Shop> CreateAsync(Shop shop)
    {
      await _context.Shop.AddAsync(shop);
      await _context.SaveChangesAsync();
      return shop;
    }

    public async Task<Shop?> DeleteAsync(int id)
    {
      var shop = await _context.Shop.FirstOrDefaultAsync(x => x.Id == id);

      if (shop == null)
      {
        return null;
      }

      _context.Shop.Remove(shop);
      await _context.SaveChangesAsync();
      return shop;
    }

    public async Task<List<Shop>> GetAllAsync(QueryObject query)
    {
      var shops = _context.Shop.Include(s => s.Products).AsQueryable();

      if (!string.IsNullOrWhiteSpace(query.CompanyName)) 
      {
        shops = shops.Where(s => s.CompanyName.Contains(query.CompanyName));
      }

      if (!string.IsNullOrWhiteSpace(query.Location))
      {
        shops = shops.Where(s => s.Location.Contains(query.Location));
      }

      return await shops.ToListAsync();
    }

    public async Task<Shop?> GetByIdAsync(int id)
    {
      return await _context.Shop.Include(s => s.Products).FirstOrDefaultAsync(i => i.Id == id);
    }

    public Task<bool> ShopExists(int id)
    {
      return _context.Shop.AnyAsync(s => s.Id == id);
    }

        public async Task<Shop?> UpdateAsync(int id, CreateShopDto shop)
    {
      var existingShop = await _context.Shop.FirstOrDefaultAsync(x => x.Id == id);

      if (existingShop == null)
      {
        return null;
      }

      existingShop.CompanyName = shop.CompanyName;
      existingShop.Location = shop.Location;
      existingShop.Industry = shop.Industry;
      existingShop.Type = shop.Type;

      await _context.SaveChangesAsync();

      return existingShop;
    }
  }
}

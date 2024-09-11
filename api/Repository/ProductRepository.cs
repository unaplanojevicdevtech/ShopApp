using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ProductRepository: IProductRepository
  {
    private readonly ApplicationDBContext _context;

    public ProductRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Product> CreateAsync(Product productModel)
    {
      await _context.Products.AddAsync(productModel);
      await _context.SaveChangesAsync();
      return productModel;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
      var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

      if (product == null)
      {
        return null;
      }

      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public async Task<Product?> UpdateAsync(int id, Product productModel)
    {
      var existingProduct = await _context.Products.FindAsync(id);

      if (existingProduct == null)
      {
        return null;
      }

      existingProduct.Name = productModel.Name;
      existingProduct.Price = productModel.Price;
      existingProduct.IsAvailable = productModel.IsAvailable;

      await _context.SaveChangesAsync();

      return existingProduct;
    }
  }
}
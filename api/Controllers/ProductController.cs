using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/product")]
  [ApiController]
  public class ProductController: ControllerBase
  {
    private readonly ApplicationDBContext _context;

    private readonly IProductRepository _repo;

    public ProductController(ApplicationDBContext context, IProductRepository repo)
    {
      _context = context;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var products = await _repo.GetAllAsync();
      var productsDto = products.Select(p => p.ToProductDto());

      return Ok(productsDto);
    }
  }
}
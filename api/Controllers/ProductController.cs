using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/product")]
  [ApiController]
  public class ProductController: ControllerBase
  {
    private readonly IProductRepository _repo;
    private readonly IShopRepository _shopRepo;

    public ProductController(IProductRepository repo, IShopRepository shopRepo)
    {
      _repo = repo;
      _shopRepo = shopRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var products = await _repo.GetAllAsync();
      var productsDto = products.Select(p => p.ToProductDto());

      return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var product = await _repo.GetByIdAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      return Ok(product.ToProductDto());
    }
    
    [HttpPost("{shopId}")]
    public async Task<IActionResult> Create([FromRoute] int shopId, CreateProductDto productDto)
    {
      if (!await _shopRepo.ShopExists(shopId))
      {
        return BadRequest("Shop does not exist");
      }

      var productModel = productDto.ToProductFromCreate(shopId); // shouldn't productDto also be sent?
      await _repo.CreateAsync(productModel);
      return CreatedAtAction(nameof(GetById), new { id = productModel }, productModel.ToProductDto());
    }
  }
}
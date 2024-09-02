using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Shop;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/shop")]
  [ApiController]
  public class ShopController: ControllerBase
  {
    private readonly ApplicationDBContext _context;
    public ShopController(ApplicationDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
      var shops = await _context.Shop.ToListAsync();
      var shopDto = shops.Select(s => s.ToShopDto());
      // should we return shopDto?
      return Ok(shops);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var shop = await _context.Shop.FindAsync(id);

      if (shop ==  null) {
        return NotFound();
      }

      return Ok(shop.ToShopDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShopDto shopDto)
    {
      var shopModel = shopDto.ToShopFromCreateDto();
      await _context.Shop.AddAsync(shopModel);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = shopModel.Id }, shopModel.ToShopDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateShopDto shopDto)
    {
      var shopModel = await _context.Shop.FirstOrDefaultAsync(x => x.Id == id);

      if (shopModel == null)
      {
        return NotFound();
      }

      shopModel.CompanyName = shopDto.CompanyName;
      shopModel.Location = shopDto.Location;
      shopModel.Industry = shopDto.Industry;
      shopModel.Type = shopDto.Type;

      await _context.SaveChangesAsync();

      return Ok(shopModel.ToShopDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var shopModel = await _context.Shop.FirstOrDefaultAsync(x => x.Id == id);

      if (shopModel == null)
      {
        return NotFound();
      }

      _context.Shop.Remove(shopModel);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
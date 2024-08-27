using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Shop;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll() 
    {
      var shops = _context.Shop.ToList()
        .Select(s => s.ToShopDto());
      return Ok(shops);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var shop = _context.Shop.Find(id);

      if (shop ==  null) {
        return NotFound();
      }

      return Ok(shop.ToShopDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateShopDto shopDto)
    {
      var shopModel = shopDto.ToShopFromCreateDto();
      _context.Shop.Add(shopModel);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = shopModel.Id }, shopModel.ToShopDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] CreateShopDto shopDto)
    {
      var shopModel = _context.Shop.FirstOrDefault(x => x.Id == id);

      if (shopModel == null)
      {
        return NotFound();
      }

      shopModel.CompanyName = shopDto.CompanyName;
      shopModel.Location = shopDto.Location;
      shopModel.Industry = shopDto.Industry;
      shopModel.Type = shopDto.Type;

      _context.SaveChanges();

      return Ok(shopModel.ToShopDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      var shopModel = _context.Shop.FirstOrDefault(x => x.Id == id);

      if (shopModel == null)
      {
        return NotFound();
      }

      _context.Shop.Remove(shopModel);
      _context.SaveChanges();

      return NoContent();
    }


  }
}
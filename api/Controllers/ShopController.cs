using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Shop;
using api.Helpers;
using api.Interfaces;
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
    private readonly IShopRepository _repo;

    public ShopController(ApplicationDBContext context, IShopRepository repo)
    {
      _context = context;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query) 
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
  
      var shops = await _repo.GetAllAsync(query);
      var shopDto = shops.Select(s => s.ToShopDto());
      // should we return shopDto?
      return Ok(shops);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var shop = await _repo.GetByIdAsync(id);

      if (shop ==  null) {
        return NotFound();
      }

      return Ok(shop.ToShopDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShopDto shopDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var shopModel = shopDto.ToShopFromCreateDto();
      await _repo.CreateAsync(shopModel);
      return CreatedAtAction(nameof(GetById), new { id = shopModel.Id }, shopModel.ToShopDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateShopDto shopDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var shopModel = await _repo.UpdateAsync(id, shopDto);

      if (shopModel == null)
      {
        return NotFound();
      }

      return Ok(shopModel.ToShopDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var shopModel = await _repo.DeleteAsync(id);

      if (shopModel == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}
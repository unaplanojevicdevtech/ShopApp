using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
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
      var shops = _context.Shop.ToList();
      return Ok(shops);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var shop = _context.Shop.Find(id);

      if (shop ==  null) {
        return NotFound();
      }

      return Ok(shop);
    }

  }
}
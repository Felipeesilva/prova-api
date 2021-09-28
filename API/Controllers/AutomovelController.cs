using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/automovel")]
    public class AutomovelController : ControllerBase
    {
      private readonly DataContext _context;
      public AutomovelController(DataContext context)
      {
        _context = context;
      }

      //POST: api/automovel/create
      [HttpPost]
      [Route("create")]
      public IActionResult Create([FromBody] Automovel automovel)
      {
          _context.Automoveis.Add(automovel);
          _context.SaveChanges();
          return Created("", automovel);
      }

        //GET: api/automovel/list
      [HttpGet]
      [Route("list")]
      public IActionResult List() => Ok(_context.Automoveis.ToList());
      

      //GET: api/automovel/getbyid/1
      [HttpGet]
      [Route("getbyid/{id}")]

      public IActionResult GetById ([FromRoute] int id)
      {
        Automovel automovel = _context.Automoveis.Find(id);
        if (automovel == null)
        {
          return NotFound();
        }
        
        return Ok(automovel);
      }

      //DELETE: /api/automovel/delete/marca
      [HttpDelete]
      [Route("delete/{marca}")]
      public IActionResult Delete([FromRoute] string marca)
      {
        
        // Buscar um objeto na tabela de produtos com base na marca
        Automovel automovel = _context.Automoveis.FirstOrDefault(automovel => automovel.Marca == marca);
        if(automovel == null)
        {
          return NotFound();
        }
        _context.Automoveis.Remove(automovel);
        _context.SaveChanges();
        return Ok(_context.Automoveis.ToList());
      }

      //PUT: api/automovel/update
      [HttpPut]
      [Route("update")]
      public IActionResult Update([FromBody] Automovel automovel)
      {
        _context.Automoveis.Update(automovel);
        _context.SaveChanges();
        return Ok(automovel);
      }
    }
}
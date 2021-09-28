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
      

    }
}
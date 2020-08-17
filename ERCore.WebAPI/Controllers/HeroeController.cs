using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERCore.Domain;
using ERCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ERCore.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HeroeController : ControllerBase
  {
    public readonly HeroeContext _context;
    public HeroeController(HeroeContext context)
    {
      _context = context;
    }

    //private static readonly string[] Summaries = new[]
    //{
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //private readonly ILogger<HeroeController> _logger;

    //public HeroeController(ILogger<HeroeController> logger)
    //{
    //  _logger = logger;
    //}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Heroe>>> Get()
    {
      //var listHeroe = (from h in _context.Heroes select h).ToList();
      var listHeroe = _context.Heroes.ToList();
      return listHeroe;
    }

    [HttpGet("{nameHeroe}")]
    public ActionResult Get(string nameHeroe)
    {
      var heroe = new Heroe() { name = nameHeroe };

      _context.Add(heroe);
      _context.SaveChanges();

      return Ok();
    }

    [HttpGet("filter/{name}")]
    public async Task<ActionResult<IEnumerable<Heroe>>> GetFilter(string name)
    {
      //var listHeroe = (from h in _context.Heroes where h.name.Contains(name) select h).ToList();
      var listHeroe = _context.Heroes
                      .Where(h => h.name.Contains(name))  
                      .ToList();
      return listHeroe;
    }

    [HttpGet("update/{id}/{value}")]
    public async Task<ActionResult<Heroe>> UpdateNameHeroe(int id, string value)
    {
      var heroe = _context.Heroes
                  .Where(h => h.id == id)
                  .FirstOrDefault();

      heroe.name = value;

      _context.SaveChanges();
      
      return heroe;
    }

    [HttpGet("remove/{id}")]
    public async Task<string> RemoveHeroe(int id)
    {
      var heroe = _context.Heroes
                  .Where(h => h.id == id)
                  .Single();

      _context.Heroes.Remove(heroe);
      _context.SaveChanges();

      return heroe.name + " removido com sucesso!";
    }
  }
}

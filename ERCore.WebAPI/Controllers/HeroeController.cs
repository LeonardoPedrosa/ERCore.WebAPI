using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERCore.Domain;
using ERCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Heroe>>> Get()
    {
      try
      {
        //var listHeroe = (from h in _context.Heroes select h).ToList();
        var listHeroe = _context.Heroes.ToList();
        return listHeroe;
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }
   

    [HttpPost]
    public ActionResult Post(Heroe model)
    {
      try
      {        
        _context.Heroes.Add(model);
        _context.SaveChanges();

        return Ok("Bazinga!");
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }


    [HttpPut("{id}")]
    public ActionResult Put(int id, Heroe model)
    {
      try
      {
        if (_context
          .Heroes
          .AsNoTracking()
          .FirstOrDefault(h => h.id == id) != null)
        {

          _context.Heroes.Update(model);
          _context.SaveChanges();

          return Ok("Bazinga!");
        }

        return BadRequest("Não encontrado!");
        
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }

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

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      try
      {
        Heroe heroe = _context
          .Heroes
          .AsNoTracking()
          .FirstOrDefault(h=> h.id == id);

        if (heroe != null)
        {
          _context.Remove(heroe);
          _context.SaveChanges();

          return Ok("BAZINGA!");
        }
        else
        {
          return BadRequest("Não encotrado!");
        }
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }
  }
}

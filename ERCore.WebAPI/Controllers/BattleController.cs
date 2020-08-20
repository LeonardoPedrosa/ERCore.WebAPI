using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERCore.Domain;
using ERCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERCore.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BattleController : ControllerBase
  {
    public readonly HeroeContext _context;
    public BattleController(HeroeContext context)
    {
      _context = context;
    }
    // GET: api/<BattleController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Battle>>> Get()
    {
      var list = _context.Battles.ToList();

      return list;
    }

    // GET api/<BattleController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<BattleController>
    [HttpPost]
    public ActionResult Post(Battle model)
    {
      try
      {
        _context.Battles.Add(model);
        _context.SaveChanges();

        return Ok("Bazinga!");
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }

    // PUT api/<BattleController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, Battle model)
    {
      try
      {
        if (_context
        .Battles
        .AsNoTracking()
        .FirstOrDefault(b => b.id == id) != null)
        {
          _context.Update(model);
          _context.SaveChanges();

          return Ok("BAZINGA!");
        }
        else
        {
          return BadRequest("Não encontrado!");
        }
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      
    }

    // DELETE api/<BattleController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      try
      {
        Battle battle = _context
          .Battles
          .AsNoTracking()
          .FirstOrDefault(b => b.id == id);

        if(battle != null)
        {
          _context.Remove(battle);
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

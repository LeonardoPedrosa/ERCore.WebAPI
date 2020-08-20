using System;
using System.Threading.Tasks;
using EFCore.Repository;
using ERCore.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ERCore.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HeroeController : ControllerBase
  {
    public readonly IEFCoreRepository _repo;
    public HeroeController(IEFCoreRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var listHeroe = _repo.GetAll();
        return Ok(listHeroe);
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        var heroe = _repo.GetHeroeById(id);
        return Ok(heroe);
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Heroe model)
    {
      try
      {
        _repo.Add(model);
        if (await _repo.SaveChangeAsync())
        {
          return Ok("Bazinga!");
        }
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      return BadRequest("Não salvou!");
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Heroe model)
    {
      try
      {
        var heroe = _repo.GetHeroeById(id);
        if (heroe != null)
        {
          _repo.Update(model);

          if (await _repo.SaveChangeAsync())
            return Ok("BAZINGA!");
        }        
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      return BadRequest("Não encontrado!");
    }
    

    //[HttpGet("{nameHeroe}")]
    //public ActionResult Get(string nameHeroe)
    //{
    //  var heroe = new Heroe() { name = nameHeroe };

    //  _context.Add(heroe);
    //  _context.SaveChanges();

    //  return Ok();
    //}

    //[HttpGet("filter/{name}")]
    //public async Task<ActionResult<IEnumerable<Heroe>>> GetFilter(string name)
    //{
    //  //var listHeroe = (from h in _context.Heroes where h.name.Contains(name) select h).ToList();
    //  var listHeroe = _context.Heroes
    //                  .Where(h => h.name.Contains(name))  
    //                  .ToList();
    //  return listHeroe;
    //}

    //[HttpGet("update/{id}/{value}")]
    //public async Task<ActionResult<Heroe>> UpdateNameHeroe(int id, string value)
    //{
    //  var heroe = _context.Heroes
    //              .Where(h => h.id == id)
    //              .FirstOrDefault();

    //  heroe.name = value;

    //  _context.SaveChanges();
      
    //  return heroe;
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, Heroe model)
    {
      try
      {
        var heroe = _repo.GetHeroeById(id);
        if(heroe != null)
        {
          _repo.Delete(model);
        }
          if(await _repo.SaveChangeAsync())        
            return Ok("BAZINGA!");
      }        
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      return BadRequest("Não encontrado!");
    }
  }
}

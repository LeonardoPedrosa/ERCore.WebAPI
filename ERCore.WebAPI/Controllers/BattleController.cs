using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repository;
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
    private readonly IEFCoreRepository _repo;
    public BattleController(IEFCoreRepository repo)
    {
      this._repo = repo;
    }
    // GET: api/<BattleController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var battles = await _repo.GetAllBattle(true);

        return Ok(battles);
      }
      catch (Exception e)
      {
        return BadRequest($"Erro {e.Message}");
      }      
    }

    // GET api/<BattleController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      try
      {
        var battle = await _repo.GetBattlesById(id, true);
        return Ok(battle);
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
    }

    // POST api/<BattleController>
    [HttpPost]
    public async Task<IActionResult> Post(Battle model)
    {
      try
      {
        _repo.Add(model);

        if(await _repo.SaveChangeAsync())
        {
          return Ok("Bazinga!");
        }         
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      return BadRequest("Não salvou.");
    }

    // PUT api/<BattleController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Battle model)
    {
      try
      {
        var battle = await _repo.GetBattlesById(id);
        if (battle != null)
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
      return BadRequest("Não encotrado!");
    }  

    // DELETE api/<BattleController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var battle = await _repo.GetBattlesById(id);
        if (battle != null)
        {
          _repo.Delete(battle);

          if(await _repo.SaveChangeAsync())
            return Ok("BAZINGA!");
        }
      }
      catch (Exception e)
      {
        return BadRequest($"Erro: {e.Message}");
      }
      return BadRequest("Não encotrado!");
    }
  }
}

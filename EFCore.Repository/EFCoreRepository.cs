using ERCore.Domain;
using ERCore.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
  public class EFCoreRepository : IEFCoreRepository
  {
    private HeroeContext _context;

    public EFCoreRepository(HeroeContext context)
    {
      this._context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }
    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }

    public async Task<bool> SaveChangeAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

    public async Task<Heroe[]> GetAll(bool includeBattle = false)
    {
      IQueryable<Heroe> query = _context.Heroes
        .Include(h => h.secretIdentity)
        .Include(h => h.weapons);

      if (includeBattle)
      {
        query = query.Include(h => h.heroBattles)
          .ThenInclude(hb => hb.battle);
      }

      query = query.AsNoTracking().OrderBy(h => h.id);

      return await query.ToArrayAsync();
    }

    public async Task<Heroe> GetHeroeById(int id, bool includeBattle = false)
    {
      IQueryable<Heroe> query = _context.Heroes
       .Include(h => h.secretIdentity)
       .Include(h => h.weapons);

      if (includeBattle)
      {
        query = query.Include(h => h.heroBattles)
          .ThenInclude(hb => hb.battle);
      }

      query = query.AsNoTracking().OrderBy(h => h.id);

      return await query.FirstOrDefaultAsync(h => h.id == id);
    }

    public async Task<Heroe[]> GetHeroesByName(string name, bool includeBattle = false)
    {
      IQueryable<Heroe> query = _context.Heroes
       .Include(h => h.secretIdentity)
       .Include(h => h.weapons);

      if (includeBattle)
      {
        query = query.Include(h => h.heroBattles)
          .ThenInclude(hb => hb.battle);
      }

      query = query
        .AsNoTracking()
        .Where(h => h.name.Contains(name))
        .OrderBy(h => h.id);

      return await query.ToArrayAsync();
    }

    public async Task<Battle[]> GetAllBattle(bool includeHeroes = false)
    {
      IQueryable<Battle> query = _context.Battles;

      if (includeHeroes)
      {
        query = query.Include(b => b.HeroeBattles)
          .ThenInclude(b => b.heroe);
      }

      query = query.AsNoTracking().OrderBy(h => h.id);

      return await query.ToArrayAsync();
    }

    public async Task<Battle> GetBattlesById(int id, bool includeHeroes = false)
    {
      IQueryable<Battle> query = _context.Battles;

      if (includeHeroes)
      {
        query = query.Include(h => h.HeroeBattles)
          .ThenInclude(b => b.heroe);
      }

      query = query.AsNoTracking().OrderBy(h => h.id);

      return await query.FirstOrDefaultAsync();
    }
  }
}

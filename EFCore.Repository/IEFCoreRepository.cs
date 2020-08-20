using ERCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repository
{
  public interface IEFCoreRepository
  {
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    Task<bool> SaveChangeAsync();

    Task<Heroe[]> GetAll(bool includeBattle = false);
    Task<Heroe> GetHeroeById(int id, bool includeBattle = false);
    Task<Heroe[]> GetHeroesByName(string name, bool includeBattle = false);

    Task<Battle[]> GetAllBattle(bool includeBattle = false);
    Task<Battle> GetBattlesById(int id, bool includeBattle = false);
  }
}

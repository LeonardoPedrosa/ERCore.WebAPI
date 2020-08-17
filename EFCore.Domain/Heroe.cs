using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCore.Domain
{
  public class Heroe
  {
    public int id { get; set; }
    public string name { get; set; }
    public SecretIdentity secretIdentity { get; set; }
    public List<HeroeBattle> heroBattles { get; set; }
    public List<Weapon> weapons { get; set; }
  }
}

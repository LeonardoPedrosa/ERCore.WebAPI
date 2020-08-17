using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCore.Domain
{
  public class HeroeBattle
  {
    public int heroeId { get; set; }
    public int battleId { get; set; }
    public Heroe heroe { get; set; }
    public Battle battle { get; set; }

  }
}

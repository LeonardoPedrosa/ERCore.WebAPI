using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERCore.WebAPI.Model
{
  public class Battle
  {
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime DtBegin { get; set; }
    public DateTime DatEnd { get; set; }
    public List<HeroeBattle> HeroeBattles { get; set; }
  }
}

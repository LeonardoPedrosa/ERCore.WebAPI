using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCore.Domain
{
  public class Weapon 
  {
    public int id { get; set; }
    public string name { get; set; }
    public int heroeId { get; set; }
    public Heroe heroe { get; set; }
  }
}

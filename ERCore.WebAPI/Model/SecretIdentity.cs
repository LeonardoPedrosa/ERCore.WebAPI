using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCore.WebAPI.Model
{
  public class SecretIdentity
  {
    public int id { get; set; }
    public string realName { get; set; }
    public int heroeId { get; set; }
    public Heroe hero { get; set; }
  }
}

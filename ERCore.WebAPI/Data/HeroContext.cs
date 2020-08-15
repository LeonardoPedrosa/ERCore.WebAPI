using ERCore.WebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ERCore.WebAPI.Data
{
  public class HeroContext : DbContext
  {
    public DbSet<Heroe> Heroes { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<HeroeBattle> HeroeBattles { get; set; }
    public DbSet<SecretIdentity> SecretIdentities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Password=swiftpro;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=DELLAVILA20\SQLEXPRESS");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<HeroeBattle>(entity =>
      {
        entity.HasKey(e => new { e.heroeId, e.battleId });
      });
    }

  }
}

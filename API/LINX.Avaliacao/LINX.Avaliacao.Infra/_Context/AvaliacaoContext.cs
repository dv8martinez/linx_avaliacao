using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Infra._map;
using Microsoft.EntityFrameworkCore;

namespace LINX.Avaliacao.Infra._Context
{
  public class AvaliacaoContext: DbContext
  {
  
    public AvaliacaoContext(DbContextOptions<AvaliacaoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new MapTipoBalanco());
      modelBuilder.ApplyConfiguration(new MapBalanco());

    }

    public DbSet<Balanco> Balancos { get; set; }
    public DbSet<TipoBalanco> TipoBalancos { get; set; }
  }
}

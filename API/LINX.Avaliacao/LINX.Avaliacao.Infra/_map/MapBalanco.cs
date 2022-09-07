using LINX.Avaliacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LINX.Avaliacao.Infra._map
{
  public class MapBalanco : IEntityTypeConfiguration<Balanco>
  {
    public void Configure(EntityTypeBuilder<Balanco> builder)
    {
      builder.ToTable("TBL_BALANCO");

      
      builder.HasKey(x => x.Id);
      

      builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(50).IsRequired();
      builder.Property(x => x.Data).HasColumnName("Data").HasColumnType("date").IsRequired();
      builder.Property(x => x.Valor).HasColumnName("Valor").HasColumnType("decimal").IsRequired();
      builder.Property(x => x.TipoId).HasColumnName("TipoId").HasColumnType("uniqueidentifier").HasMaxLength(50).IsRequired();

      builder.HasOne(x => x.Tipo).WithMany(b => b.Balanco).HasForeignKey(f => f.TipoId);

      

      

      

    }
  }
}

using LINX.Avaliacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Infra._map
{
  public class MapTipoBalanco : IEntityTypeConfiguration<TipoBalanco>
  {
    public void Configure(EntityTypeBuilder<TipoBalanco> builder)
    {
      builder.ToTable("TBL_BALANCO_TIPO");


      builder.Ignore(a => a.Balanco);

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(50).IsRequired();

     

      


    }
  }
}

using LINX.Avaliacao.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Entities
{
  public class TipoBalanco: EntityBase
  {
    public TipoBalanco(string descricao)
    {
      Descricao = descricao;      
    }

    public string Descricao { get; private set; }
    
    [JsonIgnore]    
    public virtual IEnumerable<Balanco> Balanco { get; set; }
    
  }
}

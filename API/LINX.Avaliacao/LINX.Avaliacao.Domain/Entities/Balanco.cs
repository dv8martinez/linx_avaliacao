using LINX.Avaliacao.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINX.Avaliacao.Domain.Entities
{
  public class Balanco: EntityBase  {

    public Balanco(string descricao, DateTime data, decimal valor, Guid tipoId, TipoBalanco tipo)
    {
      Descricao = descricao;
      Data = data;
      Valor = valor;
      TipoId = tipoId;
      Tipo = tipo;
    }

    public string Descricao { get; private set; }
    public DateTime Data { get; private set; }
    public decimal Valor { get; private set; }
    public Guid TipoId { get; private set; }    
    public TipoBalanco Tipo { get; private set; }
  }
}

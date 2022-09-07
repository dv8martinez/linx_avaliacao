using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Interfaces.Services
{
  public interface ITipoBalancoService
  {
    Task<ResponseModel<TipoBalanco>> GetAll();
    Task<ResponseModel<TipoBalanco>> GetById(Guid id);
    Task<Guid> Add(TipoBalanco args);
    Task<ResponseModel<Balanco>> Update(TipoBalanco args);
    Task<bool> Delete(Guid id);

  }
}

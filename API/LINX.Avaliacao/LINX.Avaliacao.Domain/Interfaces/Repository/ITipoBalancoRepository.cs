using LINX.Avaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Interfaces.Repository
{
  public interface ITipoBalancoRepository
  {
    Task<List<TipoBalanco>> GetAll();
    Task<TipoBalanco> GetById(Guid id);
    Task<Guid> Add(TipoBalanco args);
    Task<Balanco> Update(TipoBalanco args);
    Task<bool> Delete(Guid id);
  }
}

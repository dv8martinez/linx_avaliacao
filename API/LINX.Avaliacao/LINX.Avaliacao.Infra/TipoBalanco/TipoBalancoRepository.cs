using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Infra.TipoBalancos
{
  public class TipoBalancoRepository : ITipoBalancoRepository
  {
    public Task<Guid> Add(TipoBalanco args)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<List<TipoBalanco>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<TipoBalanco> GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<Balanco> Update(TipoBalanco args)
    {
      throw new NotImplementedException();
    }
  }
}

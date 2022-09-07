using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Services;
using LINX.Avaliacao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Service.TipoBalancos
{
  public class TipoBalancoService : ITipoBalancoService
  {
    public Task<Guid> Add(TipoBalanco args)
    {
      throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<ResponseModel<TipoBalanco>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<ResponseModel<TipoBalanco>> GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<ResponseModel<Balanco>> Update(TipoBalanco args)
    {
      throw new NotImplementedException();
    }
  }
}

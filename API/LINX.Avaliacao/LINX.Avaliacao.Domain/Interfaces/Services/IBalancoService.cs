using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Interfaces.Services
{
  public interface IBalancoService
  {
    Task<ResponseModel<Balanco>> GetAll(DateTime? date = null);
    Task<ResponseModel<Balanco>> GetById(Guid id);
    Task<Guid> Add(Balanco args);
    Task<ResponseModel<Balanco>> Update(Balanco args);
    Task<bool> Delete(Guid id);
  }
}

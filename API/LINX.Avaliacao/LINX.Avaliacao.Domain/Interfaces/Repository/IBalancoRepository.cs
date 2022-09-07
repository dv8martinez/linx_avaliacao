using LINX.Avaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Domain.Interfaces.Repository
{
  public interface IBalancoRepository
  {
    Task<List<Balanco>> GetAll(DateTime? date = null);
    Task<Balanco> GetById(Guid id);
    Task<Guid> Add(Balanco args);
    Task<Balanco> Update(Balanco args);
    Task<bool> Delete(Guid id);
  }
}

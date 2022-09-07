using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Repository;
using LINX.Avaliacao.Infra._Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Infra.Balancos
{
  public class BalancoRepository : IBalancoRepository
  {
    private readonly AvaliacaoContext _context;
    public BalancoRepository(AvaliacaoContext context)
    {
      _context = context;
    }
    public async Task<Guid> Add(Balanco args)
    {
      try
      {
        await _context.Balancos.AddAsync(args);
        await _context.SaveChangesAsync();

        return args.Id;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);

      }
    }

    public async Task<bool> Delete(Guid id)
    {
      try
      {
        var balancoEncontrado = await GetById(id);

        if (balancoEncontrado != null)
        {
          _context.Balancos.Remove(balancoEncontrado);
          await _context.SaveChangesAsync();
          return true;
        }
        else
        {
          return false;
        }

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);

      }
    }

    public async Task<List<Balanco>> GetAll(DateTime? date = null)
    {
      try
      {
        var result = await _context.Balancos
                             .Where(b => b.Data == (date ?? b.Data))
                             .OrderBy(b => b.Data)
                            .AsNoTracking()
                            .Include(b => b.Tipo)
                            .ToListAsync();

        return result;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);

      }
    }

    public async Task<Balanco> GetById(Guid id)
    {
      try
      {
        var result = await _context.Balancos.Where(x => x.Id == id).AsNoTracking().Include(b => b.Tipo).FirstOrDefaultAsync();

        return result;

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);

      }
    }

    public async Task<Balanco> Update(Balanco args)
    {
      try
      {
        try
        {
          var balancoEncontrado = await GetById(args.Id);

          if (balancoEncontrado != null)
          {
            _context.Balancos.Update(balancoEncontrado);
            await _context.SaveChangesAsync();
            return args;
          }
          else
          {
            return null;
          }

        }
        catch (Exception ex)
        {
          throw new Exception(ex.Message);

        }

      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);

      }
    }
  }
}

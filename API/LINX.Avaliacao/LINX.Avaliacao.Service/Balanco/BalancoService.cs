using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Repository;
using LINX.Avaliacao.Domain.Interfaces.Services;
using LINX.Avaliacao.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Service.Balancos
{
  public class BalancoService : IBalancoService
  {
    private readonly ILogger<BalancoService> _logger;
    private readonly IBalancoRepository _repository;    

    public BalancoService(ILogger<BalancoService> logger, IBalancoRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    public async Task<Guid> Add(Balanco args)
    {
      try
      {
        return await _repository.Add(args);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"[ERROR] => Falha ao Adicionar Balanco: {ex.Message}");
        throw;
      }
    }

    public async Task<bool> Delete(Guid id)
    {
      try
      {
        return await _repository.Delete(id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"[ERROR] => Falha ao Remover Balanco: {ex.Message}");
        throw;
      }
    }

    public async Task<ResponseModel<Balanco>> GetAll(DateTime? date = null)
    {
      try
      {
        var response = new ResponseModel<Balanco>(await _repository.GetAll(date));
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"[ERROR] => Falha ao Listar Balancos: {ex.Message}");
        throw;
      }
    }

    public async Task<ResponseModel<Balanco>> GetById(Guid id)
    {
      try
      {
        var response = new ResponseModel<Balanco>(await _repository.GetById(id));
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"[ERROR] => Falha ao Buscar Balanco: {ex.Message}");
        throw;
      }
    }

    public async Task<ResponseModel<Balanco>> Update(Balanco args)
    {
      try
      {
        var response = new ResponseModel<Balanco>(await _repository.Update(args));
        return response;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"[ERROR] => Falha ao Atualizar Balanco: {ex.Message}");
        throw;
      }
    }
  }
}

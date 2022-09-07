using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Application.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class BalancoController : ControllerBase
  {


    /// <summary>
    /// Adicionar novo balanco
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       
    ///
    /// </remarks>        
    /// <returns></returns>
    /// <response code="200">Result OK</response>
    /// <response code="400">Bad Request</response>  
    /// <response code="500">Erro interno do servidor</response>  
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromServices] IBalancoService service, [FromBody] Balanco args )
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        var _result = await service.Add(args);
        return Ok(_result);

      }
      catch (Exception ex)
      {
        
        return BadRequest($"Falha ao adicionar novo balanco: {ex.Message}");
      }
    }

    /// <summary>
    /// Atualizar balanço
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       
    ///
    /// </remarks>        
    /// <returns></returns>
    /// <response code="200">Result OK</response>
    /// <response code="400">Bad Request</response>  
    /// <response code="500">Erro interno do servidor</response>  
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Put([FromServices] IBalancoService service, [FromBody] Balanco args, Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        var _result = await service.Update(args);
        return Ok(_result);

      }
      catch (Exception ex)
      {

        return BadRequest($"Falha ao Atualizar balanço: {ex.Message}");
      }
    }

    /// <summary>
    /// Apagar balanço
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       
    ///
    /// </remarks>        
    /// <returns></returns>
    /// <response code="200">Result OK</response>
    /// <response code="400">Bad Request</response>  
    /// <response code="500">Erro interno do servidor</response>  
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete([FromServices] IBalancoService service,  Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        var _result = await service.Delete(id);
        return Ok(_result);

      }
      catch (Exception ex)
      {

        return BadRequest($"Falha ao Remover balanço: {ex.Message}");
      }
    }

    /// <summary>
    /// Listar balanços
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       
    ///
    /// </remarks>        
    /// <returns></returns>
    /// <response code="200">Result OK</response>
    /// <response code="400">Bad Request</response>  
    /// <response code="500">Erro interno do servidor</response>  
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetAll([FromServices] IBalancoService service)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        var _result = await service.GetAll();
        return Ok(_result);

      }
      catch (Exception ex)
      {

        return BadRequest($"Falha ao Listar balanços: {ex.Message}");
      }
    }

    /// <summary>
    /// Buscar Balanço por ID
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       
    ///
    /// </remarks>        
    /// <returns></returns>
    /// <response code="200">Result OK</response>
    /// <response code="400">Bad Request</response>  
    /// <response code="500">Erro interno do servidor</response>  
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetByID([FromServices] IBalancoService service, Guid id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {

        var _result = await service.GetById(id);
        return Ok(_result);

      }
      catch (Exception ex)
      {

        return BadRequest($"Falha ao Buscar balanço: {ex.Message}");
      }
    }
  }
}

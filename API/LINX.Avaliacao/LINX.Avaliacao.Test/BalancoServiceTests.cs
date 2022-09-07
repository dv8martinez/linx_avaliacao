using LINX.Avaliacao.Domain.Entities;
using LINX.Avaliacao.Domain.Interfaces.Repository;
using LINX.Avaliacao.Service.Balancos;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LINX.Avaliacao.Test
{
  public class BalancoServiceTests
  {
    private readonly Mock<ILogger<BalancoService>> _logger;
    private readonly Mock<IBalancoRepository> _mockRepo;
    private readonly BalancoService _balancoService;

    public BalancoServiceTests()
    {
      _logger = new Mock<ILogger<BalancoService>>();
      _mockRepo = new Mock<IBalancoRepository>();
      _balancoService = new BalancoService(_logger.Object, _mockRepo.Object);
    }

    [Fact]
    public async Task GetAll_Success(){
      //Arrange
      var tipoDespesa = new TipoBalanco("Despesa");
      var tipoReceita = new TipoBalanco("Receita");
      var resultadoEsperado = new List<Balanco>()
      {
        new Balanco("Teste despesa", DateTime.Now, Convert.ToDecimal(1234.33) ,tipoDespesa.Id, tipoDespesa),
        new Balanco("Teste Receita", DateTime.Now, Convert.ToDecimal(2022.09) ,tipoReceita.Id, tipoReceita)
      };
      //Act
        _mockRepo.Setup(m => m.GetAll(null)).ReturnsAsync(resultadoEsperado);

       var resultado = await _balancoService.GetAll(null);
      //Assert
      Assert.True(resultado.Items.Any());
    }
  }
}

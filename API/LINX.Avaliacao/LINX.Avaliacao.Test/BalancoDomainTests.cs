using LINX.Avaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LINX.Avaliacao.Test
{
  public class BalancoDomainTests
  {
    [Fact]
    public void CriarBalancoTest()
    {
      //Arrange
      var balancoTipo = new TipoBalanco("Receita");
      var balanco = new Balanco("Teste Receita", DateTime.Now, Convert.ToDecimal(2022.09) ,balancoTipo.Id, balancoTipo);
      //Act
      var balancoResult = new Balanco(balanco.Descricao, balanco.Data, balanco.Valor, balanco.TipoId, balanco.Tipo);
      //Assert
      Assert.NotNull(balancoResult);
      Assert.NotEqual(balanco.Id, balancoResult.Id);
      Assert.Equal(balanco.TipoId, balancoResult.TipoId);
      Assert.Equal(balanco.Descricao, balancoResult.Descricao);
      Assert.Equal(balanco.Data, balancoResult.Data);
      Assert.Equal(balanco.Valor, balancoResult.Valor);
      Assert.Equal(balanco.Tipo, balancoTipo);
      Assert.Equal(balancoResult.Tipo, balancoTipo);
    }
  }
}

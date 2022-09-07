using LINX.Avaliacao.Domain.Interfaces.Repository;
using LINX.Avaliacao.Infra.Balancos;
using LINX.Avaliacao.Infra.TipoBalancos;
using Microsoft.Extensions.DependencyInjection;

namespace LINX.Avaliacao.CrossCutting.DependenyInjection
{
  public static class ConfigureRepositories
  {
    public static void ConfigureDependencyRepositories(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<ITipoBalancoRepository, TipoBalancoRepository>();
      serviceCollection.AddTransient<IBalancoRepository, BalancoRepository>();
    }
  }
}
